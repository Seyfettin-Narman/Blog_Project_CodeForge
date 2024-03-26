using Microsoft.AspNetCore.Http;
using SeyfBlog.Entity.Enums;
using SeyfBlog.Entity.ViewModels.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.Helpers.Images
{
    public interface IImageHelper
    {
        void Delete(string imageName);
        Task<ImageViewModel> Upload(string Name, IFormFile imageFile,ImageType imageType ,string folderName = null);
    }
}
