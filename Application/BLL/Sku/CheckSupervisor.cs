using DAO.Sku;
using DateModel.Sku;
using Interface.Sku;
using Supervisor.Sku;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.CustomException;
using ViewModel.Sku;

namespace BLL.Sku
{
    public class CheckSupervisor : BaseBLL, ICheckSupervisor
    {
        private ICheckRepository _checkDao;
        private ISkuRepository _skuDao;
        public CheckSupervisor(ICheckRepository checkDao = null, ISkuRepository skuDao = null)
        {
            _checkDao = InitDAO<CheckDao>(checkDao) as ICheckRepository;
            _skuDao = new SkuDao(_checkDao.Repository);
        }

        public async Task<string> Add(CheckAddModel model)
        {
            // 查重
            IEnumerable<CheckSkuAddModel> checkSkuAddList = model.checkSkuAddList;
            List<CheckSkuAddModel> list = checkSkuAddList.Distinct(new CheckSkuAddModelComparer()).ToList();
            if (checkSkuAddList.Count() != list.Count())
            {
                throw new MyServiceException(MsgCode.SameData, "存在相同数据");
            }
            // 是否已经存在盘点单
            bool exist = await _checkDao.IsExistByCheckNo(model.CheckNo);
            if (exist)
            {
                throw new MyServiceException(MsgCode.SameData, "该盘点单已经添加");
            }
            // 计算总金额，相差值 -- 前端计算
            // ...
            // 添加
            return await _checkDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 添加盘点单
                string checkId = await _checkDao.Insert(ModelToEntityNoId(model), transaction);
                // 添加盘点库存信息
                foreach (var checkSkuAdd in checkSkuAddList)
                {
                    checkSkuAdd.CheckId = checkId;
                    await _checkDao.InsertCheckSku(CheckSkuModelToEntityNoId(checkSkuAdd), transaction);
                }

                return checkId;
            });
        }

        public async Task<IEnumerable<CheckModel>> GetAll()
        {
            // 1. 获取盘点单
            IEnumerable<CheckModel> modelList =  await _checkDao.SelectAll();
            // 2. 获取盘点单的库存数据
            foreach(var model in modelList)
            {
                model.CheckSkuList = await _checkDao.SelectCheckSkuByCheckId(model.Id);
                foreach(var sku in model.CheckSkuList)
                {
                    await SetCheckSkuAttrAndAddress(sku);
                }
            }
            return modelList;
        }
        public async Task SetCheckSkuAttrAndAddress(CheckSkuModel sku)
        {
            // 获取属性值
            sku.AttrList = await _skuDao.SelectAttrBySkuId(sku.SkuId);
            // 获取位置信息
            sku.Address = await _skuDao.SelectAddressByAddressId(sku.AddressId);
        }

        public async Task<PageModel<CheckModel>> GetListPageBySearch(CheckPageSearchModel model)
        {
            // 获取CheckList
            PageModel<CheckModel> pageModel = await _checkDao.GetCheckPageBySearch(model);
            // 获取CheckSkuList
            foreach (var check in pageModel.Items)
            {
                foreach(var sku in check.CheckSkuList)
                {
                    await SetCheckSkuAttrAndAddress(sku);
                }
            }
            return pageModel;
        }
        /// <summary>
        /// 一键更新状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAllStatus(CheckUpdateModel model)
        {
            return await _checkDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 1. 更新SMS_CHECK 状态和备注
                bool res = await _checkDao.UpdateCheckStatusById(model, transaction);
                // 2. 更新checksku 状态
                if (res)
                {
                    return await _checkDao.UpdateCheckSkuStatusByCheckId(model.Id, transaction);
                }
                return res;
            });
        }

        public async Task<bool> UpdateCheckSkuStatus(IEnumerable<CheckUpdateModel> modelList)
        {
            return await _checkDao.Repository.DbSession.TransactionHandle(async (transaction) =>
            {
                // 1. 更新盘点库存备注和处理状态
                await UpdateCheckSkuListStatus(modelList, transaction);
                // 判断是否还有未处理的checksku
                bool res2 = await _checkDao.HasCheckSkuToDealByCheckSkuId(modelList.ElementAt(0).Id, transaction);
                if (!res2)
                {
                    // 没有了，修改盘点单状态
                    return await _checkDao.UpdateCheckStatusByCheckSkuId(modelList.First().Id, transaction);
                }
                return true;
            });
        }
        public async Task UpdateCheckSkuListStatus(IEnumerable<CheckUpdateModel> modelList, IDbTransaction transaction = null)
        {
            foreach(var model in modelList)
            {
                await _checkDao.UpdateCheckSkuStatus(model, transaction);
            }
        }


        public SMS_CHECK_SKU CheckSkuModelToEntityNoId(CheckSkuAddModel model)
        {
            return new SMS_CHECK_SKU
            {
                CHECK_ID = model?.CheckId,
                ADDRESS_ID = model?.AddressId,
                CHECK_NUM = (int)model?.CheckNum,
                PRICE = (decimal)model?.Price,
                CHECK_PRICE = (decimal)model?.CheckPrice,
                ACCOUNT_NUM = (int)model?.AccountNum,
                ACCOUNT_PRICE = (decimal)model?.AccountPrice,
                DIFFERENCE_NUM = (int)model?.DifferenceNum,
                DIFFERENCE_PRICE = (decimal)model?.DifferencePrice,
                STATUS = (int)model?.Status,
                DESCRIPTION = model?.Description
            };
        }
        public SMS_CHECK ModelToEntityNoId(CheckAddModel model = null)
        {
            return new SMS_CHECK
            {
                CHECK_NO = model?.CheckNo,
                OPERATOR = model?.Operator,
                CHECK_DATE = (DateTime)model?.CheckDate,
                ACCOUNT_PRICE = (decimal)model?.AccountPrice,
                CHECK_PRICE = (decimal)model?.CheckPrice,
                DIFFERENCE_PRICE = (decimal)model?.DifferencePrice,
                DESCRIPTION = model?.Description,
                STATUS = (int)model?.Status
            };
        }
        public SMS_CHECK ModelToEntity(CheckModel model)
        {
            SMS_CHECK entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
    }
    /// <summary>
    ///  EntrySkuModel 去重比较器
    /// </summary>
    public class CheckSkuAddModelComparer : IEqualityComparer<CheckSkuAddModel>
    {
        public bool Equals(CheckSkuAddModel x, CheckSkuAddModel y)
        {
            //这里定义比较的逻辑
            return x.SkuId == y.SkuId && x.Status == y.Status && x.AddressId == y.AddressId;
        }

        public int GetHashCode(CheckSkuAddModel obj)
        {
            //返回字段的HashCode，只有HashCode相同才会去比较
            return (obj.SkuId + obj.Status + obj.AddressId).GetHashCode();
        }
    }
}
