using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SeyfBlog.Data.Units;
using SeyfBlog.Service.Services.Abstract;
using SeyfBlog.Entity.ViewModels.Posts;
using FluentValidation;
using SeyfBlog.Entity.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SeyfBlog.Service.Extensions;
using NToastNotify;
using SeyfBlog.Web.NotifyMessages;
using Microsoft.AspNetCore.Authorization;
using SeyfBlog.Web.Consts;
namespace SeyfBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Post> validator;
        private readonly IToastNotification toast;

        public PostController(IPostService postService, ICategoryService categoryService,IMapper mapper,IValidator<Post> validator , IToastNotification toast)
        {
            this.postService = postService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}, {ConstRole.User}")]
        public async Task<IActionResult> Index()
        {
            var posts = await postService.GetAllPostsWithCategory();
            return View(posts);
        }
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> DeletedPosts()
        {
            var posts = await postService.GetAllDeletedPosts();
            return View(posts);
        }

        [HttpGet]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Add()
        {
          
            var categories = await categoryService.GetAllCategories();
            return View(new AddPostViewModel {Categories = categories });
        }
        [HttpPost]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Add(AddPostViewModel addPostViewModel)
        {
            var map = mapper.Map<Post>(addPostViewModel);
            var r = await validator.ValidateAsync(map);
            if (r.IsValid)
            {
                await postService.CreatePost(addPostViewModel);
                toast.AddSuccessToastMessage(Messages.Post.Add(addPostViewModel.Title),new ToastrOptions {Title = "Başarılı" });
                return  RedirectToAction("Index", "Post", new { Area = "Admin" });

            }
            else
            {
                r.AddToModelState(this.ModelState);
     
            }

            var categories = await categoryService.GetAllCategories();
            return View(new AddPostViewModel { Categories = categories });
        }
        [HttpGet]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Update(Guid postId)
        {
            var post = await postService.GetPostsWithCategory(postId);
            var categories = await categoryService.GetAllCategories();
            var updatePostViewModel = mapper.Map<UpdatePostViewModel>(post);
            updatePostViewModel.Categories= categories;
            return View(updatePostViewModel);
        }
        [HttpPost]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Update(UpdatePostViewModel updatePostViewModel)
        {
            var map = mapper.Map<Post>(updatePostViewModel);
            var r = await validator.ValidateAsync(map);
            if (r.IsValid)
            {
                var title= await postService.UpdatePost(updatePostViewModel);
                toast.AddSuccessToastMessage(Messages.Post.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
               return  RedirectToAction("Index", "Post", new { Area = "Admin" });
            }
            else
            {
                r.AddToModelState(this.ModelState);
            }
          
            var categories = await categoryService.GetAllCategories();
            updatePostViewModel.Categories = categories;
            
            return View(updatePostViewModel);
        }
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Delete(Guid postId)
        {
            var title = await postService.SeyfDelete(postId);
            toast.AddWarningToastMessage(Messages.Post.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Post", new { Area = "Admin" });
        }
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> UndoDelete(Guid postId)
        {
            var title = await postService.UndoDelete(postId);
            toast.AddSuccessToastMessage(Messages.Post.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Post", new { Area = "Admin" });
        }
    }
}
