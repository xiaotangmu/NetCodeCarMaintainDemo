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
    /// 一级分类
    /// </summary>
    [SwaggerControllerGroup("Catalog1", "一级分类")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class Catalog1Controller : BaseController
    {
        private ICatalog1Supervisor _catalog1Supervisor;

        public Catalog1Controller (ICatalog1Supervisor catalog1Supervisor)
        {
            _catalog1Supervisor = catalog1Supervisor;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Catalog1AddModel model)
        {
            return await ResponseResult(async () =>
            {
                string result = await _catalog1Supervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("添加一级分类：") + model.CatalogName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("添加失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ResponseResult(async () =>
            {
                return await _catalog1Supervisor.GetAll();
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(Catalog1Model model)
        {
            return await ResponseResult(async () =>
            {
                bool result =  await _catalog1Supervisor.Update(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("更新一级分类：") + model.CatalogName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("更新失败"));
                }
                return result;
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Catalog1Model model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _catalog1Supervisor.Delete(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("删除一级分类：") + model.CatalogName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("删除失败"));
                }
                return result;
            });
        }

    }
}
