using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Categories;
using SeyfBlog.Entity.ViewModels.Posts;
using SeyfBlog.Service.Services.Abstract;
using SeyfBlog.Service.Services.Concrete;
using SeyfBlog.Web.Consts;
using SeyfBlog.Web.NotifyMessages;
using System.ComponentModel.DataAnnotations;

namespace SeyfBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public CategoryController(ICategoryService categoryService,IValidator<Category> validator, IMapper mapper,IToastNotification toast)
        {
            this.categoryService = categoryService;
            this.validator = validator;
            this.mapper = mapper;
            this.toast = toast;
        }
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}, {ConstRole.User}")]
        public  async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategories();
            return View(categories);
        }
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> DeletedCategory()
        {
            var categories = await categoryService.GetAllDeletedCategories();
            return View(categories);
        }
        [HttpGet]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Add(AddCategoryViewModel addCategoryViewModel)
        {
            var map = mapper.Map<Category>(addCategoryViewModel);
            var r = await validator.ValidateAsync(map);
            if (r.IsValid)
            {
                await categoryService.CreateCategory(addCategoryViewModel);
                toast.AddSuccessToastMessage(Messages.Category.Add(addCategoryViewModel.Name), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Category", new { Area = "Admin" });

            }
            r.AddToModelState(this.ModelState);
            return View();
        }
        [HttpGet]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Update(Guid categoryId)
        {
            var category = await categoryService.GetCategoryByGuid(categoryId); ;
            return View(new UpdateCategoryViewModel() {Id = category.Id, Name = category.Name });
        }
        [HttpPost]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Update(UpdateCategoryViewModel updateCategoryViewModel)
        {
            var map = mapper.Map<Category>(updateCategoryViewModel);
            var r = await validator.ValidateAsync(map);
            if (r.IsValid)
            {
                var name = await categoryService.UpdateCategory(updateCategoryViewModel);
                toast.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction( "Index","Category", new {Area = "Admin"});
            }
            r.AddToModelState(this.ModelState);
            return View();
        }
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            var name = await categoryService.SeyfDeleteCategory(categoryId);
            toast.AddWarningToastMessage(Messages.Category.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid categoryId)
        {
            var name = await categoryService.UndoDeleteCategory(categoryId);
            toast.AddSuccessToastMessage(Messages.Category.UndoDelete(name), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
    }
}
