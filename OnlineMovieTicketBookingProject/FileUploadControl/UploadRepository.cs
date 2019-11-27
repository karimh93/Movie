using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileUploadControl
{
    public class UploadRepository:IUpload
    {
        private IHostingEnvironment hostingEnvironment;
        
        public UploadRepository(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
    
        public async void uploadMultipleFiles(IList<IFormFile> files)
        {
            long totalBytes = files.Sum(f => f.Length);
            
            foreach(var item in files)
            {
                string fileName = item.FileName.Trim('"');
                byte[] buffer = new byte[16];
                using(FileStream output = System.IO.File.Create(this.GetpathAndFileName(fileName)))
                {
                    using(Stream input = item.OpenReadStream())
                    {
                        
                        int readBytes;
                        while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }

        private string GetpathAndFileName(string fileName)
        {
            string path = this.hostingEnvironment.WebRootPath + "\\uploads";
            if (Directory.Exists(path))
            
                Directory.CreateDirectory(path);
                return path + fileName;
            
        }
    }
}
