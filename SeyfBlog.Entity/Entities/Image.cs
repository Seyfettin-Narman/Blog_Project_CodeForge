using SeyfBlog.Core.Entities;
using SeyfBlog.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.Entities
{
    public class Image : EntityBase
    {
   

        public string FileName { get; set; }
        public string FileType { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<IdUser> Users { get; set; }
        public Image(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }
        public Image()
        {
            
        }
    }
}
