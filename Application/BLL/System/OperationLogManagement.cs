using DAO.System;
using DataAccess;
using DataModel.System;
using Entity.Sys;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class OperationLogManagement
    {
        private readonly OperationLogDAO _dao;

        public OperationLogManagement(IDataRepository repository = null) 
        {
            _dao = new OperationLogDAO(repository);
        }

        /// <summary>
        /// 写操作日志
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="requestUrl">请求资源URL</param>
        /// <param name="requestArgs">请求URL参数</param>
        /// <param name="operation">操作方法描述</param>
        /// <returns></returns>
        public async Task<bool> WriteOperationLog(CurrentUserInfo userInfo, OperationElement elements)
        {
            SYSTEM_OPERATION_LOG log = new SYSTEM_OPERATION_LOG
            {
                CONTENT = elements.Operation,
                OPERATION_TIME = DateTime.Now,
                URL_ARGS = elements.RequestArgs,
                URL = elements.RequestUrl,
                LOGIN_NAME = userInfo.Name
            };
            return await _dao.InsertAsync(log);
        }


        public async Task<OperationLogTableModel> Search(LogSearchModel search)
        {
            OperationLogTableModel table = new OperationLogTableModel();
            table.TotalCount = await _dao.GetCount(search);
            if (table.TotalCount == 0)
            {
                return table;
            }
            IEnumerable<SYSTEM_OPERATION_LOG> data = await _dao.GetAsync(search);
            if (data == null)
            {
                return table;
            }
            table.Data = BuildModels(data);
            return table;
        }

        private List<OperationLogViewModel> BuildModels(IEnumerable<SYSTEM_OPERATION_LOG> enumerable)
        {
            List<OperationLogViewModel> models = new List<OperationLogViewModel>();
            foreach (SYSTEM_OPERATION_LOG log in enumerable.ToList())
            {
                models.Add(BuildModel(log));
            }
            return models;
        }

        private OperationLogViewModel BuildModel(SYSTEM_OPERATION_LOG log)
        {
            OperationLogViewModel model = new OperationLogViewModel();
            model.Operation = log.CONTENT;
            model.LogTime = log.OPERATION_TIME.ToString();
            model.LoginName = log.LOGIN_NAME;
            return model;
        }
    }

    public class OperationElement
    {
        /// <summary>
        /// 请求url
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// 请求url的参数
        /// </summary>
        public string RequestArgs { get; set; }

        /// <summary>
        /// 操作描述
        /// </summary>
        public string Operation { get; set; }
    }
}
