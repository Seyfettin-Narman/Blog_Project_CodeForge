using SeyfBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
        public int Views { get; set; } = 0;
        public Guid UserId { get; set; }
        public IdUser User { get; set; }
        public Post()
        {

        }
        public Post(string title, string createdBy , Guid userId, string content, Guid categoryId, Guid imageId)
        {
            Title = title;
            CreatedBy = createdBy;
            UserId = userId;
            Content = content;
            CategoryId = categoryId;
            ImageId = imageId;
            
        }




    }
}
