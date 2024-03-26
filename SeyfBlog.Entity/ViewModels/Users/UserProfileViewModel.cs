﻿using Microsoft.AspNetCore.Http;
using SeyfBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.ViewModels.Users
{
    public class UserProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public IFormFile? Photo { get; set; }
        public Image Image { get; set; }
    }
}
