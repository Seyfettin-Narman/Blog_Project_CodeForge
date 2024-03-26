using SeyfBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
     
        
      
        public ICollection<Post> Posts { get; set; }

        public Category()
        {
            
        }
        public Category(string name , string creatingBy)
        {
            Name = name;
            CreatedBy = creatingBy;
        }
    }
}
