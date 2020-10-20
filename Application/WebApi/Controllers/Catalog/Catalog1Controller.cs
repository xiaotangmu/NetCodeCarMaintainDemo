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

        public Catalog1Controller (ICatalog1Supervisor catalog1Supervisor) : base()
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
                if (string.IsNullOrWhiteSpace(model.CatalogName))
                {
                    throw new Exception(("数据异常"));
                }
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

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(Catalog1Model model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Id) || string.IsNullOrWhiteSpace(model.CatalogName))
                {
                    throw new Exception(("数据异常"));
                }
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

        /// <summary>
        /// 删除分类及其子分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(Catalog1Model model)
        {
            return await ResponseResult(async () =>
            {
                if (string.IsNullOrWhiteSpace(model.Id) )
                {
                    throw new Exception(("数据异常"));
                }
                bool result = await _catalog1Supervisor.Delete(model.Id);
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
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBatch(IEnumerable<Catalog1AddModel> models)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _catalog1Supervisor.AddBatch(models);
                if (result)
                {
                    foreach (var model in models)
                    {
                        // 添加二级分类：一级分类id ：一级分类名
                        await LogOperation(await Localizer.GetValueAsync("添加一级分类：") + model.CatalogName);
                    }
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("批量添加一级分类失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeletBatch(IEnumerable<Catalog1Model> models)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _catalog1Supervisor.DeleteBatch(models);
                if (result)
                {
                    foreach (var model in models)
                    {
                        // 批量删除一级分类：一级分类id ：分类名
                        await LogOperation(await Localizer.GetValueAsync("删除一级分类：") + model.Id + " : " + model.CatalogName);
                    }
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("批量删除一级分类失败"));
                }
                return result;
            });
        }

    }
}
