using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileUploadControl
{
    public interface IUpload
    {

        void uploadMultipleFiles(IList<IFormFile> files);
    
    
    
    }
}
