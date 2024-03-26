using Microsoft.AspNetCore.Http;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.ViewModels.Posts
{
    public class UpdatePostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IList<CategoryViewModel> Categories { get; set; }
        public Image Image { get; set; }
        public IFormFile? imageFile { get; set; }
    }
}
