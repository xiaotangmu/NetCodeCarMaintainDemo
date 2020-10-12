using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace WebApi.Services
{
    /// <summary>
    /// 资产图片生成器
    /// </summary>
    public class AssetImgGenerator
    {
        private const string BASE_PATH = "Images";
        private IHostingEnvironment _hostingEnvironment;

        public AssetImgGenerator(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        ///// <summary>
        ///// 创建图片文件
        ///// </summary>
        ///// <param name="img"></param>
        ///// <returns></returns>
        //public string CreateFile(ImgModel img)
        //{
        //    if (img == null || string.IsNullOrEmpty(img.ImgData))
        //    {
        //        return string.Empty;
        //    }

        //    var fileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff") + ".txt";
        //    string PhysicalPath = Path.Combine(_hostingEnvironment.ContentRootPath, BASE_PATH);

        //    if (!Directory.Exists(PhysicalPath))
        //    {
        //        Directory.CreateDirectory(PhysicalPath);
        //    }

        //    PhysicalPath = Path.Combine(PhysicalPath, fileName);
        //    //保存到指定路径
        //    using (StreamWriter sw = File.AppendText(PhysicalPath))
        //    {
        //        sw.Write(img.ImgData);
        //    }

        //    return Path.Combine("\\", BASE_PATH, fileName);
        //}
    }
}
