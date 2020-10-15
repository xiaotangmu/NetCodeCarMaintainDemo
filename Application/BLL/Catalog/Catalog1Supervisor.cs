using DAO.Catalog;
using DateModel.Catalog;
using Interface.Catalog;
using Supervisor.Catalog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace BLL.Catalog
{
    /// <summary>
    /// 一级分类
    /// </summary>
    public class Catalog1Supervisor: BaseBLL, ICatalog1Supervisor
    {
        private ICatalog1Repository _catalog1Dao;
        public Catalog1Supervisor(ICatalog1Repository catalog1Repository = null)    // 不能少了默认值 null
        {
            _catalog1Dao = InitDAO<Catalog1Dao>(catalog1Repository) as ICatalog1Repository;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(Catalog1AddModel model)
        {
            return await _catalog1Dao.InsertAsync(ModelToEntityNoId(model));
        }

        public async Task<bool> Delete(Catalog1Model model)
        {
            return await _catalog1Dao.DeleteAsync(ModelToEntity(model));
        }

        public async Task<IEnumerable<Catalog1Model>> GetAll()
        {
            return await _catalog1Dao.SelectAllAsync();
        }

        public async Task<bool> Update(Catalog1Model model)
        {
            return await _catalog1Dao.UpdateAsync(ModelToEntity(model));
        }

        /// <summary>
        /// 将model 转换为表 entity，没有ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BMMS_CATALOG1 ModelToEntityNoId(Catalog1AddModel model = null)
        {
            return new BMMS_CATALOG1
            {
                CATALOG_NAME = model?.CatalogName,
                DESCRIPTION = model?.Description
            };
        }
        /// <summary>
        /// 将model 转换为表 entity 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BMMS_CATALOG1 ModelToEntity(Catalog1Model model)
        {
            BMMS_CATALOG1 entity = ModelToEntityNoId(model);
            entity.ID = model.Id;
            return entity;
        }
    }
}
