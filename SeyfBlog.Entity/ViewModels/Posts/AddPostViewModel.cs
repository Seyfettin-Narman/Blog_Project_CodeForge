using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SeyfBlog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.ViewModels.Posts
{
    public class AddPostViewModel
    {
        public readonly IFormFile FormFile;

        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IList<CategoryViewModel> Categories { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
