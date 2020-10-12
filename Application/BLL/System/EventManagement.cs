using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAO.System;
using DataModel;
using DataModel.System;
using Entity.Sys;
using Interface.System;

namespace BLL.System
{
    public class EventManagement : BaseBLL
    {
        private const string DICT_TYPE_CODE = "event_type";
        private IDictDAO _dictDAO;

        public EventManagement(IDictDAO dictDAO = null)
        {
            _dictDAO = InitDAO<DictDAO>(dictDAO) as IDictDAO;
        }

        public async Task<EventPageResult> GetPageGroup(string text, int pageIndex, int pageSize)
        {
            SYSTEM_DICT dict = new SYSTEM_DICT
            {
                TEXT = text,
                TYPE_CODE = DICT_TYPE_CODE
            };
            EventPageResult result = new EventPageResult();
            result.TotalCount = await _dictDAO.GetCount(dict);
            if (result.TotalCount > 0)
            {
                result.Items = await BuildEventResult(dict, pageIndex, pageSize);
            }
            return result;
        }

        public async Task<List<EventResult>> GetPageGroup()
        {
            SYSTEM_DICT dict = new SYSTEM_DICT
            {
                TYPE_CODE = DICT_TYPE_CODE
            };
            List<EventResult> results = await BuildEventResult(dict, -1, 1);
            return results;
        }

        private async Task<List<EventResult>> BuildEventResult(SYSTEM_DICT entity, int pageIndex, int pageSize)
        {
            List<EventResult> results = new List<EventResult>();
            IEnumerable<SYSTEM_DICT> dicts = await _dictDAO.GetPageAsync<SYSTEM_DICT>(entity, pageIndex, pageSize);
            foreach (SYSTEM_DICT dict in dicts)
            {
                results.Add(new EventResult
                {
                    Code = dict.CODE,
                    Text = dict.TEXT
                });
            }
            return results;
        }

        public async Task<string> Add(string text)
        {
            SYSTEM_DICT dict = new SYSTEM_DICT();
            dict.TYPE_CODE = DICT_TYPE_CODE;
            dict.CODE = GenerateEventCode();
            dict.TEXT = text;
            return await _dictDAO.InsertAsync(dict);
        }

        public async Task<bool> Update(string dictCode, string dictText)
        {
            UpdateModel updateModel = new UpdateModel();
            updateModel.SetCollection.Add(SYSTEM_DICT.FIELD_TEXT, dictText);
            updateModel.WhereCollection.Add(SYSTEM_DICT.FIELD_CODE, dictCode);
            updateModel.WhereCollection.Add(SYSTEM_DICT.FIELD_TYPE_CODE, DICT_TYPE_CODE);
            return await _dictDAO.EditAsync(updateModel.SetCollection,updateModel.WhereCollection);
        }

        public async Task<bool> Delete(string dictCode)
        {
            return await _dictDAO.Delete(dictCode, DICT_TYPE_CODE);
        }

        private string GenerateEventCode()
        {
            string prefix = "event_";
            return prefix + DateTime.Now.ToString("yyyyMMddhhmmss");
        }
    }

    public class EventPageResult
    {
        public long TotalCount { get; set; }

        public List<EventResult> Items { get; set; } = new List<EventResult>();
    }

    public class EventResult
    {
        public string Code { get; set; }

        public string Text { get; set; }
    }
}
