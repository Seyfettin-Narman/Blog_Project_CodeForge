using AutoMapper;
using Microsoft.AspNetCore.Http;
using SeyfBlog.Data.Units;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Categories;
using SeyfBlog.Service.Extensions;
using SeyfBlog.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnit unit;

        private readonly IMapper mapper;
        private IHttpContextAccessor accesor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnit unit, IMapper mapper, IHttpContextAccessor accesor)
        {
            this.unit = unit;
            this.mapper = mapper;
            this.accesor = accesor;
            _user = accesor.HttpContext.User;
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var userId = _user.GetLoginUserId();
            var userEmail = _user.GetLoginEmail();
            var categories = await unit.GetRepository<Category>().GetAll(x => !x.isActive);
            var map = mapper.Map<List<CategoryViewModel>>(categories);
            return map;
        }
        public async Task CreateCategory(AddCategoryViewModel addCategoryViewModel)
        {
            var userId = _user.GetLoginUserId();
            var userEmail = _user.GetLoginEmail();
            Category category = new(addCategoryViewModel.Name, userEmail);
            await unit.GetRepository<Category>().Add(category);
            await unit.SaveAsync();

        }
        public async Task<Category> GetCategoryByGuid(Guid id)
        {
            var category = await unit.GetRepository<Category>().GetByGuid(id);
            return category;
        }
        public async Task<string> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            var userEmail = _user.GetLoginEmail();
            var category = await unit.GetRepository<Category>().Get(x => !x.isActive && x.Id == updateCategoryViewModel.Id);
            category.Name = updateCategoryViewModel.Name;
            category.ModifiedBy = userEmail;
            category.ModifiedDate = DateTime.Now;
            await unit.GetRepository<Category>().Update(category);
            await unit.SaveAsync();
            return category.Name;
        }

        public async Task<string> SeyfDeleteCategory(Guid categoryId)
        {
            var userEmail = accesor.HttpContext.User.GetLoginEmail();
            var category = await unit.GetRepository<Category>().GetByGuid(categoryId);
            category.isActive = true;
            category.DeletedDate = DateTime.Now;
            category.DeletedBy = userEmail;
            await unit.GetRepository<Category>().Update(category);
            await unit.SaveAsync();
            return category.Name;
        }

        public async Task<List<CategoryViewModel>> GetAllDeletedCategories()
        {
   
            var categories = await unit.GetRepository<Category>().GetAll(x => x.isActive);
            var map = mapper.Map<List<CategoryViewModel>>(categories);
            return map;
        }

        public async Task<string> UndoDeleteCategory(Guid categoryId)
        {
            var category = await unit.GetRepository<Category>().GetByGuid(categoryId);
            category.isActive = false;
            category.DeletedDate =null;
            category.DeletedBy = null;
            await unit.GetRepository<Category>().Update(category);
            await unit.SaveAsync();
            return category.Name;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoriesTake()
        {
            var categories = await unit.GetRepository<Category>().GetAll(x => !x.isActive);
            var map = mapper.Map<List<CategoryViewModel>>(categories);
            return map.Take(10).ToList();
        }
    }
}
