using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.ViewModels.Posts
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public CategoryViewModel Category { get; set; }
        public string Content { get; set; }
        public bool isActive { get; set; }
        public  string CreatedBy { get; set; }
        public Image Image { get; set; }
        public  DateTime CreatedDate { get; set; }
        public IdUser User { get; set; }
        public int Views { get; set; }
    }
}
