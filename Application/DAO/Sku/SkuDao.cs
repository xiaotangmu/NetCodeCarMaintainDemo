using Dapper;
using DataModel;
using DateModel.Sku;
using Interface.Sku;
using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Sku;

namespace DAO.Sku
{
    public class SkuDao :BaseDAO, ISkuRepository
    {
        public SkuDao() { }
        public SkuDao(IDataRepository repository) : base(repository) { }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<string> Insert(SMS_SKU entity, IDbTransaction transaction = null)
        {
            return await Repository.InsertAsync<SMS_SKU>(entity, transaction);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id, IDbTransaction transaction = null)
        {
            return await Repository.DeleteAsync<SMS_SKU>(id, transaction) > 0 ? true : false;
        }

        public void Dispose()
        {
            Repository.DbSession.Connection.Close();
            Repository.DbSession.Connection.Dispose();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SkuModel>> SelectAll()
        {
            //string sql = @"select * from SMS_SKU where 1 = 1";
            //IEnumerable<SMS_SKU> entities =  await Repository.GetGroupAsync<SMS_SKU>(sql);
            //return EntityListToModelList(entities);


            //using (IDbConnection conn = (SqlConnection)Repository.DbSession.Connection)
            //{
            //    string sql = "SELECT a.*,c.*,e.* FROM t_operator a left join t_operator_group b on a.id = b.operatorid left join t_group c on c.id=b.groupid " +
            //            "left join t_operator_rights d on a.id = d.operatorid left join t_rights e on e.id = d.rightid";
            //    var lookup = new Dictionary<string, SkuModel>();
            //    object p = await Repository.QueryAsync<SkuModel, SkuAttr, SkuModel>(sql, (o, g) =>
            //    {
            //        SkuModel tmp;
            //        if (!lookup.TryGetValue(o.Id, out tmp))
            //        {
            //            tmp = o;
            //            lookup.Add(o.Id, tmp);
            //        }
            //        SkuAttr tmpG = tmp.attrList.Find(f => f.AttrId == g.AttrId);
            //        if (tmpG == null)
            //        {
            //            tmpG = g;
            //            tmp.attrList.Add(tmpG);
            //        }

            //        return o;
            //    },
            //    splitOn: "id");
            //    return lookup.Values.ToList();
            //}

            return null;
        }

        public Task<IEnumerable<SkuModel>> SelectListBySearch(string searchStr)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SkuModel>> SelectListPage(BaseSearchModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SkuModel>> SelectListPageBySearch(SkuListSearchModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SMS_SKU sMS_SKU, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public SkuModel EntityToModel(SMS_SKU entity)
        {
            return new SkuModel
            {
                Id = entity?.ID,
                SkuNo = entity?.SKU_NO,
                SkuName = entity?.SKU_NAME,
                Room = entity?.ROOM,
                Self = entity?.SELF,
                Brand = entity?.BRAND,
                Price = (int)entity?.PRICE,
                Quantity = (int)entity?.QUANTITY,
                Alarm = (int)entity?.ALARM,
                Description = entity?.DESCRIPTION,
                Type = entity?.TYPE,
                Status = (int)entity?.STATUS,
                OldPartId = entity?.OLD_PARTID,
                Catalog2Id = entity?.CATALOG2_ID,
                OCD = (DateTime)entity?.OCD,
                LUD = (DateTime)entity?.LUD
            };
        }
        public IEnumerable<SkuModel> EntityListToModelList(IEnumerable<SMS_SKU> entityList)
        {
            List<SkuModel> modelList = new List<SkuModel>();
            foreach (var entity in entityList)
            {
                modelList.Add(EntityToModel(entity));
            }
            return modelList;
        }
    }
}
