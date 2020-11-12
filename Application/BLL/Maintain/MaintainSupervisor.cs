using DAO.Maintain;
using DAO.Sku;
using DateModel.Maintain;
using Interface.Maintain;
using Interface.Sku;
using Supervisor.Maintain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.CustomException;
using ViewModel.Maintain;
using ViewModel.Sku;

namespace BLL.Maintain
{
    public class MaintainSupervisor: BaseBLL, IMaintainSupervisor
    {
        private IMaintainRepository _mainDao;
        private IOutRepository _outDao;
        private ISkuRepository _skuDao;
        public MaintainSupervisor(IMaintainRepository mainDao = null, IOutRepository outDao = null,
            ISkuRepository skuDao = null)
        {
            _mainDao = InitDAO<MaintainDao>(mainDao) as IMaintainRepository;
            _outDao = new OutDao(_mainDao.Repository);
            _skuDao = new SkuDao(_mainDao.Repository);
        }

        public async Task<string> Add(MaintainAddModel model)
        {
            // OutId 查重
            HashSet<string> outIdSet = new HashSet<string>(model.OutIdList);
            if(outIdSet.Count() != model.OutIdList.Count())
            {
                throw new MyServiceException("出库单重复");
            }
            // ToolList 查重
            List<MaintainToolAddModel> list = model.ToolList.Distinct(new MaintainToolAddModelComparer()).ToList();
            if (model.ToolList.Count() != list.Count())
            {
                throw new MyServiceException(MsgCode.SameData, "提交的工具有相同数据");
            }
            // OldPart 配件查重
            List<MaintainOldPartAddModel> list2 = model.OldPartList.Distinct(new MaintainOldPartAddModelComparer()).ToList();
            if (model.OldPartList.Count() != list2.Count())
            {
                throw new MyServiceException(MsgCode.SameData, "提交的配件有相同数据");
            }
            // 维修单是否已经存在 -- 维修单号与预约单号相同
            int Exist = await _mainDao.IsExistByMaintainNo(model.MaintainNo);
            if (Exist > 0)
            {
                throw new MyServiceException("该维修单已经存在");
            }

            return await _mainDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 添加维修单
                string maintainId = await _mainDao.Insert(ModelToEntityNoId(model), transaction);
                // 添加工具
                foreach(var tool in model.ToolList)
                {
                    tool.MaintainId = maintainId;
                    await _mainDao.InsertTool(ToolModelToEntityNoId(tool), transaction);
                }
                // 添加出库单
                foreach(var outId in model.OutIdList)
                {
                    await _mainDao.InsertMaintainOut(OutModelToEntityNoId(outId, maintainId), transaction);
                }
                // 添加旧配件
                foreach(var old in model.OldPartList)
                {
                    old.MaintainId = maintainId;
                    await _mainDao.InsertOldPart(OldPartModelToEntityNoId(old), transaction);
                }
                return maintainId;
            });
        }

        public async Task<bool> Delete(string id)
        {
            // 查看是否有没处理的工具
            await IsSureToDeleteOrThrowException(id);
            // 删除
            return await _mainDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 删除关联数据
                // 删除工具表
                await _mainDao.DeleteToolByMaintainId(id, transaction);
                // 删除配件表 -- 不能删除，绑定入库信息
                try
                {
                    await _mainDao.DeleteOldPartByMaintainId(id, transaction);
                }catch(Exception e)
                {
                    throw new MyServiceException("该配件已入库，需要绑定来源，请先将该库存和对应入库信息删除");
                }
                // 删除维修单
                return await _mainDao.Delete(id, transaction);
            });
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBatch(IEnumerable<MaintainDeleteModel> modelList)
        {
            // 查看是否可以删除
            foreach (var item in modelList)
            {
                await IsSureToDeleteOrThrowException(item.Id);
            }
            // 删除
            return await _mainDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                foreach (var item in modelList)
                {
                    // 删除关联数据
                    // 删除工具表
                    await _mainDao.DeleteToolByMaintainId(item.Id, transaction);
                    // 删除配件表 -- 不能删除，绑定入库信息
                    try
                    {
                        await _mainDao.DeleteOldPartByMaintainId(item.Id, transaction);
                    }
                    catch (Exception e)
                    {
                        throw new MyServiceException("该配件已入库，需要绑定来源，请先将该库存和对应入库信息删除");
                    }
                    // 删除维修单
                    await _mainDao.Delete(item.Id, transaction);
                }
                return true;
            });
        }

        /// <summary>
        /// 判断是否可以删除/是否还有未处理项
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsSureToDeleteOrThrowException(string id)
        {
            // 查看是否有没处理的工具
            bool res1 = await _mainDao.HasNoDealToolByMaintainId(id);
            if (res1)
            {
                throw new MyServiceException("还有未处理的工具，请先处理");
            }
            // 查看是否有没处理的配件
            bool res2 = await _mainDao.HasNoDealOlPartByMaintainId(id);
            if (res2)
            {
                throw new MyServiceException("还有未处理的配件，请先处理");
            }
            // 查看是否已经标记签字/取消
            bool res3 = await _mainDao.IsNoSignByMaintainId(id);
            if (res3)
            {
                throw new MyServiceException("该维修单没有签字完成或取消，不能删除");
            }
            return res3;
        }

        public async Task<IEnumerable<MaintainShowModel>> GetAll()
        {
            // 获取维修单
            IEnumerable<MaintainShowModel> modelList =  await _mainDao.SelectAll();
            return await GetPartList(modelList);
        }

        /// <summary>
        /// 获取工具/配件信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MaintainShowModel>> GetPartList(IEnumerable<MaintainShowModel> modelList)
        {
            foreach (var model in modelList)
            {
                await GetPart(model);
            }
            return modelList;
        }
        public async Task GetPart(MaintainShowModel model)
        {
            if(model == null || string.IsNullOrWhiteSpace(model.Id))
            {
                return;
            }
            // 获取维修工具
            IEnumerable<MaintainToolModel> toolList = await _mainDao.GetToolsByMaintainId(model.Id);
            foreach (var tool in toolList)
            {
                // 获取工具规格
                IEnumerable<SkuAttrModel> attrList = await _mainDao.GetToolTypeById(tool.Id);
                tool.AttrList = attrList;
            }
            model.ToolList = toolList;
            // 获取维修旧配件
            IEnumerable<MaintainOldPartModel> oldPartList = await _mainDao.GetOldPartsByMaintainId(model.Id);
            foreach (var old in oldPartList)
            {
                // 获取旧配件规格
                IEnumerable<SkuAttrModel> attrList = await _mainDao.GetOldPartTypeById(old.Id);
            }
            model.OldPartList = oldPartList;
            // 获取维修用到配件
            IEnumerable<SkuModel> skuList = await _mainDao.GetSkusByMaintainId(model.Id);
            foreach (var sku in skuList)
            {
                // 获取配件规格
                IEnumerable<SkuAttrModel> attrList = await _skuDao.SelectAttrBySkuId(sku.Id);
            }
            model.SkuList = skuList;
        }

        public async Task<PageModel<MaintainShowModel>> GetListPageBySearch(MaintainPageSearchModel model)
        {
            PageModel<MaintainShowModel> pageModel = await _mainDao.SelectListPageBySearch(model);
            pageModel.Items = await GetPartList(pageModel.Items);
            return pageModel;
        }

        /// <summary>
        /// 更新 -- 出库单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateWithOut(MaintainModel model)
        {
            // 判断关联项是否已经有处理的
            // 判断工具是否有处理的
            bool res1 = await _mainDao.HasDealToolByMaintainId(model.Id);
            if (res1)
            {
                throw new MyServiceException("存在工具已经处理，不能更新，或者先将该其强制修改为未处理");
            }
            // 判断旧配件是否有处理的
            //bool res2 = await _mainDao.HasDealOldPartByMaintainId(model.Id);
            //if (res2)
            //{
            //    throw new MyServiceException("存在旧配件已经处理，不能删除，或者先将该其强制修改为未处理");
            //}
            return await _mainDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 删除工具
                await _mainDao.DeleteToolByMaintainId(model.Id, transaction);
                // 删除旧配件
                //try
                //{
                //    await _mainDao.DeleteOldPartByMaintainId(model.Id, transaction);
                //}
                //catch (Exception e)
                //{
                //    throw new MyServiceException("该配件已入库，需要绑定来源，请先将该库存和对应入库信息删除");
                //}
                // 删除关联出库
                await _mainDao.DeleteMaintainOutByMaintainId(model.Id, transaction);
                // 添加工具
                foreach (var tool in model.ToolList)
                {
                    tool.MaintainId = model.Id;
                    await _mainDao.InsertTool(ToolModelToEntityNoId(tool), transaction);
                }
                // 添加旧配件
                //foreach (var old in model.OldPartList)
                //{
                //    old.MaintainId = model.Id;
                //    await _mainDao.InsertOldPart(OldPartModelToEntityNoId(old), transaction);
                //}
                // 添加出库单
                foreach (var outId in model.OutIdList)
                {
                    await _mainDao.InsertMaintainOut(OutModelToEntityNoId(outId, model.Id), transaction);
                }
                // 更新主表维修单信息
                return await _mainDao.UpdateMaintainNoRelation(model, transaction);
            });
        }
        /// <summary>
        /// 更新工具栏
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateWithTool(MaintainModel model)
        {
            // 过滤数据，只更新状态为0或者数量大于处理数量的, 工具不更新，只能更新
            return await _mainDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 更新工具
                foreach (var tool in model.ToolList)
                {
                    tool.MaintainId = model.Id;
                    await _mainDao.UpdateTool(tool, transaction);
                }
                // 更新主表维修单信息
                return await _mainDao.UpdateMaintainNoRelation(model, transaction);
            });
        }
        /// <summary>
        /// 更新配件栏
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateWithOldPart(MaintainModel model)
        {
            //// 过滤数据，只更新状态为0或者数量大于处理数量的
            //List<MaintainOldPartModel> addOldPartList = new List<MaintainOldPartModel>();    // 没有处理过的
            //List<MaintainOldPartModel> updateOldPartList = new List<MaintainOldPartModel>(); // 有处理过的，减少数量刚好等于的也要更新
            //foreach (var item in model.OldPartList)
            //{
            //    if (item.Status == 0 && item.Num < item.DealNum)
            //    {
            //        throw new MyServiceException("存在配件数量大于处理数量");
            //    }
            //    else if (item.Status == 0 && item.DealNum > 0) // 有处理过的
            //    {
            //        updateOldPartList.Add(item);
            //    }
            //    // 减少数量至刚好等于的
            //    else if (item.Status == 1 && item.Num == item.DealNum && item.Num > 0)
            //    {
            //        updateOldPartList.Add(item);
            //    }
            //    else if (item.Status == 0 && item.DealNum == 0 && item.Num > 0)
            //    {
            //        addOldPartList.Add(item);
            //    }
            //}

            return await _mainDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                //// 删除未处理的配件-- 处理的不能直接删除，绑定id
                //await _mainDao.DeleteNoDealOldPartByMaintainId(model.Id, transaction);
                //// 添加配件
                //foreach (var old in addOldPartList)
                //{
                //    old.MaintainId = model.Id;
                //    await _mainDao.InsertOldPart(OldPartModelToEntityNoId(old), transaction);
                //}

                // 删除关联旧配件信息
                await _mainDao.DeleteOldPartByMaintainId(model.Id, transaction);
                // 添加旧配件信息
                foreach(var item in model.OldPartList)
                {
                    if (item.Num < item.DealNum)
                    {
                        throw new MyServiceException("存在配件数量大于处理数量");
                    }
                    if (item.Num == item.DealNum && item.Num > 0)
                    {
                        item.Status = 1;
                    }
                    if(item.Num <= 0)
                    {
                        continue;
                    }
                    await _mainDao.InsertOldPart(OldPartModelToEntity(item), transaction);
                }

                //// 更新工具
                //foreach (var tool in updateOldPartList)
                //{
                //    tool.MaintainId = model.Id;
                //    await _mainDao.UpdateOldPart(tool, transaction);
                //}
                // 更新主表维修单信息
                return await _mainDao.UpdateMaintainNoRelation(model, transaction);
            });
        }
        public MMS_MAINTAIN_OUT OutModelToEntityNoId(string outId, string maintainId)
        {
            return new MMS_MAINTAIN_OUT
            {
                MAINTAIN_ID = maintainId,
                OUT_ID = outId
            };
        }
        public MMS_MAINTAIN_TOOL ToolModelToEntityNoId(MaintainToolAddModel model = null)
        {
            return new MMS_MAINTAIN_TOOL
            {
                MAINTAIN_ID = model?.MaintainId,
                OUT_SKU_ID = model?.OutSkuId,
                DEAL_NUM = (int)model?.DealNum,
                NUM = (int)model?.Num,
                STATUS = (int)model?.Status,
                REMARK = model?.Remark,
                COMPENSATION = (decimal)model?.Compensation
            };
        }
        public MMS_MAINTAIN_OLDPART OldPartModelToEntityNoId(MaintainOldPartAddModel model = null)
        {
            return new MMS_MAINTAIN_OLDPART
            {
                MAINTAIN_ID = model?.MaintainId,
                SKU_ID = model?.SkuId,
                NUM = (int)model?.Num,
                STATUS = (int)model?.Status,
                REMARK = model?.Remark,
                DEAL_NUM = (int)model?.DealNum
            };
        }
        public MMS_MAINTAIN_OLDPART OldPartModelToEntity(MaintainOldPartModel model = null)
        {
            MMS_MAINTAIN_OLDPART entity = OldPartModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
        public MMS_MAINTAIN ModelToEntityNoId(MaintainAddModel model = null)
        {
            return new MMS_MAINTAIN
            {
                MAINTAIN_NO = model?.MaintainNo,
                OPERATOR = model?.Operator,
                STAFF = model?.Staff,
                APPOINTMENT_ID = model?.AppointmentId,
                START_DATE = (DateTime)model?.StartDate,
                STATUS = (int)model?.Status,
                RETURN_DATE = (DateTime)model?.ReturnDate
            };
        }
        public MMS_MAINTAIN ModelToEntity(MaintainModel model)
        {
            MMS_MAINTAIN entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }

        public async Task<bool> UpdateTool(MaintainToolUpdateModel model)
        {
            return await _mainDao.UpdateTool(model);
        }

        public async Task<bool> UpdateOldPart(MaintainOldPartUpdateModel model)
        {
            return await _mainDao.UpdateOldPart(model);
        }

        /// <summary>
        /// 批量更新工具
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public async Task<bool> UpdateToolList(IEnumerable<MaintainToolUpdateModel> modelList)
        {
            return await _mainDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                foreach(var model in modelList)
                {
                    await _mainDao.UpdateTool(model, transaction);
                }
                return true;
            });
        }

        /// <summary>
        /// 批量更新旧配件
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public async Task<bool> UpdateOldPartList(IEnumerable<MaintainOldPartUpdateModel> modelList)
        {
            return await _mainDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                foreach (var model in modelList)
                {
                    await _mainDao.UpdateOldPart(model, transaction);
                }
                return true;
            });
        }

        public async Task<bool> UpdateMaintainNoRelation(MaintainModel model)
        {
            return await _mainDao.UpdateMaintainNoRelation(model);
        }

        public async Task<IEnumerable<MaintainShowModel>> GetNoDealToolOrPartWithMaintain()
        {
            IEnumerable<MaintainShowModel> modelList = await _mainDao.GetNoDealToolOrPartWithMaintain();
            // 过滤已经处理的工具或配件
            await GetPartList(modelList);
            List<MaintainToolModel> toolList = new List<MaintainToolModel>();
            List<MaintainOldPartModel> oldPartList = new List<MaintainOldPartModel>();
            foreach (var model in modelList)
            {
                foreach(var tool in model.ToolList)
                {
                    if(tool.Status == 0)
                    {
                        toolList.Add(tool);
                    }
                }
                model.ToolList = toolList;
                foreach (var old in model.OldPartList)
                {
                    if (old.Status == 0)
                    {
                        oldPartList.Add(old);
                    }
                }
                model.OldPartList = oldPartList;
            }
            return modelList;
        }

        public async Task<MaintainShowModel> GetMaintainById(string id)
        {
            MaintainShowModel model = await _mainDao.SelectMaintainAllInfoById(id);
            await GetPart(model);
            return model;
        }
    }
    /// <summary>
    ///  MaintainOldPartAddModel 去重比较器
    /// </summary>
    public class MaintainOldPartAddModelComparer : IEqualityComparer<MaintainOldPartAddModel>
    {
        public bool Equals(MaintainOldPartAddModel x, MaintainOldPartAddModel y)
        {
            //这里定义比较的逻辑
            return x.SkuId == y.SkuId;
        }

        public int GetHashCode(MaintainOldPartAddModel obj)
        {
            //返回字段的HashCode，只有HashCode相同才会去比较
            return (obj.SkuId).GetHashCode();
        }
    }
    /// <summary>
    ///  MaintainToolAddModel 去重比较器
    /// </summary>
    public class MaintainToolAddModelComparer : IEqualityComparer<MaintainToolAddModel>
    {
        public bool Equals(MaintainToolAddModel x, MaintainToolAddModel y)
        {
            //这里定义比较的逻辑
            return x.OutSkuId == y.OutSkuId;
        }

        public int GetHashCode(MaintainToolAddModel obj)
        {
            //返回字段的HashCode，只有HashCode相同才会去比较
            return (obj.OutSkuId).GetHashCode();
        }
    }
}
