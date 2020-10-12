using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi.Services.ImportExcel
{
    public class DownloadHelper
    {
        public static DownloadModel GetDownloadModel(string fileName)
        {
            IFileProvider provider = new PhysicalFileProvider(TempFileManager.TempFileDirectory);
            IFileInfo fileInfo = provider.GetFileInfo(fileName);
            var readStream = fileInfo.CreateReadStream();
            DownloadModel model = new DownloadModel
            {
                FileStream = readStream,
                ContentType = "application/octet-stream",
                DownloadFileName = fileName
            };
            return model;
        }
    }

    public class DownloadModel
    {
        public Stream FileStream { get; set; }

        public string ContentType { get; set; }

        public string DownloadFileName { get; set; }
    }
}
