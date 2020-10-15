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
        [HttpPost]
        public async Task<IActionResult> Add(Catalog2AddModel model)
        {
            return await ResponseResult(async () =>
            {
                string result = await _catalog2Supervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    await LogOperation(await Localizer.GetValueAsync("二级分类添加成功: ") + (model.Catalog1Id + " : " + model.CatalogName));
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("二级分类添加失败"));
                }
                return result;
            });
        }
        
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(Catalog2Model model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _catalog2Supervisor.Update(model);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("二级分类更新成功: ") + (model.Catalog1Id + " : " + model.CatalogName));
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("二级分类更新失败"));
                }
                return result;
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Catalog2Model model)
        {
            return await ResponseResult(async () => {
                bool result = await _catalog2Supervisor.Delete(model.Id);
                if (result)
                {
                    await LogOperation(await Localizer.GetValueAsync("成功删除二级分类: ") + (model.Id + " : " + model.CatalogName));
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("二级分类删除失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 获取二级分类
        /// </summary>
        /// <param name="Catalog1Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListByCatalog1(string Catalog1Id)
        {
            return await ResponseResult(async () =>
            {
                return await _catalog2Supervisor.GetListByCatalog1Id(Catalog1Id);
            });
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddBatch(IEnumerable<Catalog2AddModel> models)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _catalog2Supervisor.AddBatch(models);
                if (result)
                {
                    foreach (var model in models)
                    {
                        // 添加二级分类：一级分类id ：二级分类名
                        await LogOperation(await Localizer.GetValueAsync("添加二级分类：") + model.Catalog1Id + " : " + model.CatalogName);
                    }
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("批量添加二级分类失败"));
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
        public async Task<IActionResult> DeletBatch(IEnumerable<Catalog2Model> models)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _catalog2Supervisor.DeleteBatch(models);
                if (result)
                {
                    foreach (var model in models)
                    {
                        // 批量删除二级分类：一级分类id ：二级分类id ：分类名
                        await LogOperation(await Localizer.GetValueAsync("删除二级分类：") + model.Catalog1Id + " : " + model.Id + " : " + model.CatalogName);
                    }
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("批量删除二级分类失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 删除分类下所有属性
        /// </summary>
        /// <param name="CatalogId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteByCatalogId(string Catalog1Id)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _catalog2Supervisor.DeleteListByCatalog1Id(Catalog1Id);
                if (result)
                {
                    // 删除一级分类下二级分类：一级分类id 
                    await LogOperation(await Localizer.GetValueAsync("删除一级分类下二级分类：") + Catalog1Id);
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
