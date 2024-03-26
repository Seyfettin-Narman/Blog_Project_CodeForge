using AutoMapper;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryViewModel, Category>().ReverseMap();
            CreateMap<AddCategoryViewModel, Category>().ReverseMap();
            CreateMap<UpdateCategoryViewModel, Category>().ReverseMap();

        }
    }
}
