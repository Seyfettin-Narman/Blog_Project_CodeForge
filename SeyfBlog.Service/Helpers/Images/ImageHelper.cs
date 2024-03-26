using Microsoft.AspNetCore.Hosting;
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
    public class ImageHelper : IImageHelper
    {
        private const string imgFolder = "img";
        private const string postImagesFolder = "post-images";
        private const string usersImagesFolder = "user-images";
        private readonly IWebHostEnvironment env;
        private readonly string wwwroot;

        public ImageHelper(IWebHostEnvironment env)
        {
            this.env = env;
            wwwroot = env.WebRootPath;
        }
        private string ReplaceChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }
        public void Delete(string imgName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/{imgName}");

            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }
                
        }

        public async Task<ImageViewModel> Upload(string Name, IFormFile imageFile, ImageType imageType, string folderName = null)
        {
            folderName ??= imageType == ImageType.User ? usersImagesFolder : postImagesFolder;

            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");
            }
               
            string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            string fileExtension = Path.GetExtension(imageFile.FileName);
            Name = ReplaceChars(Name);
            DateTime dateTime = DateTime.Now;

            string newFileName = $"{Name}_{dateTime.Millisecond}{fileExtension}";

            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();
            string message = imageType == ImageType.User ? $"{newFileName} isimli kullanıcı resmi başarı ile eklenmiştir." : $"{newFileName} isimli gönderi resmi başarı ile eklenmiştir";

            return 
            new ImageViewModel()
            {
                FullName = $"{folderName}/{newFileName}"
            };
        }
    }
}
