using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SeyfBlog.Service.AutoMapper.Posts
{
    public  class PostProfile : Profile
    {
        public PostProfile() 
        {
            CreateMap<PostViewModel, Post>().ReverseMap();
            CreateMap<UpdatePostViewModel, Post>().ReverseMap();
            CreateMap<UpdatePostViewModel, PostViewModel>().ReverseMap();
            CreateMap<AddPostViewModel, Post>().ReverseMap();
        }
    }
}
