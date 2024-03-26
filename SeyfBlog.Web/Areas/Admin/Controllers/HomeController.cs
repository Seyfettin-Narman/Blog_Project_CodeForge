using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Service.Services.Abstract;

namespace SeyfBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPostService _postService; 
        public HomeController(IPostService _postService)
        { 
            this._postService = _postService;  

        } 
        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllPostsWithCategory();
            return View(posts.FirstOrDefault());
        }
    }
}
