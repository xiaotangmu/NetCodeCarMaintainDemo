using Interface.System;
using DataModel.System;
using Entity.Sys;
using Localization;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supervisor.System;

namespace BLL.System
{
    public class DictManagement : BaseBLL, IDictSupervisor
    {
        private const string _ROOT_TYPE = "ROOT";

        private readonly IDictDAO _dao;

        public DictManagement(IDictDAO dictDAO = null)
        {
            _dao = InitDAO<DictDAO>(dictDAO) as IDictDAO;
        }

        public async Task<List<T_SYSTEM_DICT>> GetDictData(string typeCode)
        {
            return (await _dao.GetByTypeCodeAsync(typeCode, ((int)Judge.YES).ToString())).ToList();
        }

        /// <summary>
        /// 根据父节点+子节点获取字典内容
        /// </summary>
        /// <param name="typeCode"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<string> GetDictDataText(string typeCode, string code, bool needLocalize)
        {
            T_SYSTEM_DICT dict = await _dao.GetDictData(typeCode, code);
            if (dict == null)
            {
                return string.Empty;
            }
            if (needLocalize)
            {
                return await Localizer.GetValueAsync(dict.TYPE_CODE + "_" + dict.CODE);
            }
            return dict.TEXT;
        }

        public async Task<DictPageModel> GetPageList(DictSearchPageModel searchModel)
        {
            DictPageModel model = new DictPageModel();
            T_SYSTEM_DICT dict = new T_SYSTEM_DICT
            {
                CODE = searchModel.DictCode,
                DESCRIPTION = searchModel.Description,
                ISUSE = searchModel.IsUse,
                TEXT = searchModel.DictText,
                TYPE_CODE = _ROOT_TYPE
            };
            model.TotalCount = await _dao.GetCount(dict);
            if (model.TotalCount == 0)
            {
                return model;
            }
            var dicts = await _dao.GetPageAsync<T_SYSTEM_DICT>(dict, searchModel.PageIndex, searchModel.PageSize);
            if (dicts == null)
            {
                return model;
            }
            model.Items = BuildModels(dicts);
            return model;
        }

        public async Task<List<DictViewModel>> GetChildren(DictSearchPageModel searchModel)
        {
            T_SYSTEM_DICT dict = new T_SYSTEM_DICT
            {
                CODE = searchModel.DictCode,
                DESCRIPTION = searchModel.Description,
                ISUSE = searchModel.IsUse,
                TEXT = searchModel.DictText,
                TYPE_CODE = searchModel.DictTypeCode
            };
            var dicts = await _dao.GetAllAsync(dict);//-1表示爲獲取全部數據
            if (dicts == null)
            {
                return null;
            }
            return BuildModels(dicts);
        }

        public async Task<string> Add(AddDictModel model)
        {
            string resultId = string.Empty;
            T_SYSTEM_DICT dict = BuildDictEntity(model);
            try
            {
                resultId = await _dao.InsertAsync(dict);
            }
            catch (PostgresException pgEx)
            {
                throw await ContrainExceptionFactory.Singleton.Create<T_SYSTEM_DICT>(pgEx);
            }
            return resultId;
        }

        private T_SYSTEM_DICT BuildDictEntity(AddDictModel model)
        {
            T_SYSTEM_DICT dict = new T_SYSTEM_DICT();
            dict.CODE = model.DictCode;
            dict.TEXT = model.DictText;
            dict.TYPE_CODE = string.IsNullOrEmpty(model.DictTypeCode) ? _ROOT_TYPE : model.DictTypeCode;
            if (dict.TYPE_CODE == _ROOT_TYPE)
            {
                dict.ISLEAF = ((int)Judge.NO).ToString();
            }
            else
            {
                dict.ISLEAF = ((int)Judge.YES).ToString();
            }
            dict.ISUSE = ((int)Judge.YES).ToString();
            dict.OCD = DateTime.Now;
            return dict;
        }

        public async Task<bool> Edit(AddDictModel model)
        {
            UpdateModel updateModel = new UpdateModel();
            updateModel.SetCollection.Add("text", model.DictText);
            updateModel.SetCollection.Add("description", model.Description);
            updateModel.SetCollection.Add("modify_time", DateTime.Now);
            updateModel.WhereCollection.Add("code", model.DictCode);
            updateModel.WhereCollection.Add("type_code", model.DictTypeCode);
            return await _dao.EditAsync(updateModel.SetCollection, updateModel.WhereCollection);
        }

        public async Task<bool> Delete(DeleteDictModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.DictCode))
            {
                throw new Exception(await Localizer.GetValueAsync("Data_Empty"));
            }
            return await _dao.Delete(model.DictCode, model.DictTypeCode);
        }

        public async Task<bool> Delete(string dictType)
        {
            return await _dao.Delete(dictType);
        }

        private List<DictViewModel> BuildModels(IEnumerable<T_SYSTEM_DICT> dicts)
        {
            List<DictViewModel> models = new List<DictViewModel>();
            foreach (var dict in dicts)
            {
                models.Add(new DictViewModel
                {
                    DictCode = dict.CODE,
                    DictText = dict.TEXT,
                    Description = dict.DESCRIPTION,
                    IsUse = dict.ISUSE.Equals(((int)Judge.YES).ToString()) ? true : false
                });
            }
            return models;
        }
    }
}
