using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.ViewModels.Users
{
    public  class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
       
        public bool EmailConfirmed { get; set; }
        public int AccessFailedCount { get; set; }
        
    }
}
