using Microsoft.AspNetCore.Identity;
using SeyfBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.Entities
{
    public class IdUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("15998e7d-09a4-4a76-94c8-3422fb2aedaf");
        public Image Image { get; set; }
        public ICollection<Post> Posts { get; set; }
        
    }
}
