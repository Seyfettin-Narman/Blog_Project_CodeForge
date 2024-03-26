using AutoMapper;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Posts;
using SeyfBlog.Entity.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<IdUser, UserViewModel>().ReverseMap();
            CreateMap<IdUser, AddUserViewModel>().ReverseMap();
            CreateMap<IdUser, UpdateUserViewModel>().ReverseMap();
            CreateMap<IdUser, UserProfileViewModel>().ReverseMap();
        }
    }
}
