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
    /// 属性管理
    /// </summary>
    [SwaggerControllerGroup("Attr", "属性管理")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class AttrController : BaseController
    {
        private IAttrSupervisor _attrSupervisor;

        public AttrController(IAttrSupervisor attrSupervisor)
        {
            _attrSupervisor = attrSupervisor;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(AttrAddModel model)
        {
            return await ResponseResult(async () =>
            {
                string result = await _attrSupervisor.Add(model);
                if (!string.IsNullOrEmpty(result))
                {
                    // 添加属性：分类id ：attrName
                    await LogOperation(await Localizer.GetValueAsync("添加属性：") + model.CatalogId + " : " + model.AttrName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("添加属性失败"));
                }
                return result;
            });
        }

        /// <summary>
        /// 获取分类属性
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListByCatalogId(string catalogId)
        {
            return await ResponseResult(async () =>
            {
                return await _attrSupervisor.GetListByCatalogId(catalogId);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(AttrModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _attrSupervisor.Update(model);
                if (result)
                {
                    // 更新属性：分类id ：属性id ：属性名
                    await LogOperation(await Localizer.GetValueAsync("更新属性：") + model.CatalogId + " : " + model.Id + " : " + model.AttrName);
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("更新属性失败"));
                }
                return result;
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(AttrModel model)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _attrSupervisor.Delete(model.Id);
                if (result)
                {
                    // 删除属性：分类id ：属性id ：属性名
                    await LogOperation(await Localizer.GetValueAsync("删除属性：") + model.CatalogId + " : " + model.Id + " : " + model.AttrName);
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
        public async Task<IActionResult> AddBatch(IEnumerable<AttrAddModel> models)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _attrSupervisor.AddBatch(models);
                if (result)
                {
                    foreach (var model in models)
                    {
                        // 添加属性：分类id ：属性名
                        await LogOperation(await Localizer.GetValueAsync("添加属性：") + model.CatalogId + " : " + model.AttrName);
                    }
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("批量添加属性失败"));
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
        public async Task<IActionResult> DeletBatch(IEnumerable<AttrModel> models)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _attrSupervisor.DeleteBatch(models);
                if (result)
                {
                    foreach (var model in models)
                    {
                        // 批量删除属性：分类id ：属性id ：属性名
                        await LogOperation(await Localizer.GetValueAsync("删除属性：") + model.CatalogId + " : " + model.Id + " : " + model.AttrName);
                    }
                }
                else
                {
                    throw new Exception(await Localizer.GetValueAsync("批量删除属性失败"));
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
        public async Task<ActionResult> DeleteByCatalogId(string CatalogId)
        {
            return await ResponseResult(async () =>
            {
                bool result = await _attrSupervisor.DeleteAttrListByCatalog(CatalogId);
                if (result)
                {
                    // 删除分类下属性：分类id 
                    await LogOperation(await Localizer.GetValueAsync("删除分类下属性：") + CatalogId);
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
