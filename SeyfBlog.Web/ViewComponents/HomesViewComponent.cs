using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeyfBlog.Service.Services.Abstract;

namespace SeyfBlog.Web.ViewComponents
{
    public class HomesViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public HomesViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryService.GetAllCategoriesTake();
           return View(categories);
        }
    }
}
