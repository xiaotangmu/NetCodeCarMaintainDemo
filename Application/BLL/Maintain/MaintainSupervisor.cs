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
        public MaintainSupervisor(IMaintainRepository mainDao = null, IOutRepository outDao = null)
        {
            _mainDao = InitDAO<MaintainDao>(mainDao) as IMaintainRepository;
            _outDao = new OutDao(_mainDao.Repository);
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
            bool Exist = await _mainDao.IsExistByMaintainNo(model.MaintainNo);
            if (Exist)
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

        public Task<bool> Delete(string id)
        {
            // 查看是否还有没有处理的工具和旧配件

            // 查看是否已经标记签字 -- 状态回滚？？？

        }

        public Task<bool> DeleteBatch(IEnumerable<AppointmentDeleteModel> modelList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MaintainModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PageModel<MaintainModel>> GetListPageBySearch(MaintainPageSearchModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(MaintainModel model)
        {
            throw new NotImplementedException();
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
                RETURN_NUM = (int)model?.ReturnNum,
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
                REMARK = model?.Remark
            };
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
