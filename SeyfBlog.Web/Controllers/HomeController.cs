using Microsoft.AspNetCore.Mvc;
using SeyfBlog.Service.Services.Abstract;
using SeyfBlog.Web.Models;
using System.Diagnostics;

namespace SeyfBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;

        public HomeController(ILogger<HomeController> logger,IPostService postService )
        {
            _logger = logger;
            this._postService = postService;
        }

        public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize=3, bool isAscending=false)
        {
            var posts = await _postService.GetAllByPaging(categoryId, currentPage, pageSize, isAscending);

            return View(posts);
        }
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            var posts = await _postService.Search(keyword, currentPage, pageSize, isAscending);

            return View(posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Detail(Guid postId)
        {
            var post = await  _postService.GetPostsWithCategory(postId);
            return View(post);
        }
    }
}
