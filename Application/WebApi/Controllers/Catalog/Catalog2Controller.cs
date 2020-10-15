using Localization;
using Microsoft.AspNetCore.Mvc;
using Supervisor.Catalog;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.Catalog;

namespace WebApi.Controllers.Catalog
{
    /// <summary>
    /// 二级分类
    /// </summary>
    [SwaggerControllerGroup("Catalog2", "二级分类")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class Catalog2Controller : BaseController
    {
        private ICatalog2Supervisor _catalog2Supervisor;

        public Catalog2Controller(ICatalog2Supervisor catalog2Supervisor)
        {
            _catalog2Supervisor = catalog2Supervisor;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Add(Catalog2AddModel model)
        {
            return await ResponseResult(async () =>
            {
                string result = await _catalog2Supervisor.Add(model);
                await ResponseAddLogStr(result, "二级分类添加成功", (model.Catalog1Id + " : " + model.CatalogName), "二级分类添加失败");
                return result;
            });
        }
        
        [HttpPost]
        public async Task<bool> Update(Catalog2Model model)
        {
            
            bool result = await _catalog2Supervisor.Update(model);
            await ResponseAddLogBool(result, "二级分类更新成功", (model.Catalog1Id + " : " + model.CatalogName), "二级分类更新失败");
        }

        
    }
}
