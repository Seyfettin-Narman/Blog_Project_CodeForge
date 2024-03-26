using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Users;

namespace SeyfBlog.Web.Areas.Admin.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<IdUser> userManager;
        private readonly IMapper mapper;
        public HeaderViewComponent(UserManager<IdUser> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginUser = await userManager.GetUserAsync(HttpContext.User);
            var map = mapper.Map<UserViewModel>(loginUser);
            var role = string.Join("", await userManager.GetRolesAsync(loginUser));
            map.Role = role;
            return View(map);
        }

    }
}
