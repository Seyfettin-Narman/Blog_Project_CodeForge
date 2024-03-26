using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.Services.Abstract
{
    public interface ICategoryService
    {
      
        Task<List<CategoryViewModel>> GetAllCategories();
        Task CreateCategory(AddCategoryViewModel addCategoryViewModel);
        Task<Category> GetCategoryByGuid(Guid id);
        Task<string> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel);
        Task<string> SeyfDeleteCategory(Guid categoryId);
        Task<List<CategoryViewModel>> GetAllDeletedCategories();
        Task<string> UndoDeleteCategory(Guid categoryId);
        Task<List<CategoryViewModel>> GetAllCategoriesTake();
    }
}
