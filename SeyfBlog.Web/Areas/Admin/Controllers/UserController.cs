using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using SeyfBlog.Data.Units;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.Enums;
using SeyfBlog.Entity.ViewModels.Users;
using SeyfBlog.Service.Helpers.Images;
using SeyfBlog.Service.Services.Abstract;
using SeyfBlog.Web.Consts;
using SeyfBlog.Web.NotifyMessages;
using System.Security.Claims;
using static SeyfBlog.Web.NotifyMessages.Messages;

namespace SeyfBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdUser> userManager;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;
        private readonly IValidator<IdUser> validator;
        private readonly IUserService userService;
 
        public UserController(UserManager<IdUser> userManager,IUnit unit,IValidator<IdUser> validator ,IUserService userService,  IImageHelper imageHelper,SignInManager<IdUser> signInManager, IMapper mapper,RoleManager<IdRole> roleManager, IToastNotification toast)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.toast = toast;
            this.validator = validator;
            this.userService = userService;
          

        }
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Index()
        {
            var r = await userService.GetAllUsers();
            return View(r);
        }
        [HttpGet]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Add()
        {
            var roles = await userService.GetAllRoles();
            return View(new AddUserViewModel { Roles = roles });
        }
        [HttpPost]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Add(AddUserViewModel addUserViewModel)
        {
            var map = mapper.Map<IdUser>(addUserViewModel);
            var validation = await validator.ValidateAsync(map);
            var roles = await userService.GetAllRoles();
            if (ModelState.IsValid)
            {
                var result = await userService.CreateUser(addUserViewModel);
                if(result.Succeeded)
                {
                 
                    toast.AddSuccessToastMessage(Messages.User.Add(addUserViewModel.Email), new ToastrOptions { Title = "İşlem Başarılı" });

                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    validation.AddToModelState(this.ModelState);
                    return View(new AddUserViewModel { Roles = roles });
                }
              

            }
            return View(new AddUserViewModel { Roles = roles });
        }
        [HttpGet]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userService.GetIdUserByGuid(userId);
            var roles = await userService.GetAllRoles();
            var map = mapper.Map<UpdateUserViewModel>(user);
            map.Roles = roles;
            return View(map);
        }
        [HttpPost]
        [Authorize(Roles = $"{ConstRole.Topmanager}, {ConstRole.Admin}")]
        public async Task<IActionResult> Update(UpdateUserViewModel updateUserViewModel)
        {
            var user = await userService.GetIdUserByGuid(updateUserViewModel.Id);
            if (user != null)
            {
               
                var roles = await userService.GetAllRoles();
                if (ModelState.IsValid)
                {
                  
                    user.FirstName=updateUserViewModel.FirstName;
                    user.lastName=updateUserViewModel.LastName;
                    user.Email=updateUserViewModel.Email;
                    user.UserName = updateUserViewModel.Email;
                    user.SecurityStamp=Guid.NewGuid().ToString();
                    var result = await userManager.UpdateAsync(user);
                    if(result.Succeeded)
                    {
                        toast.AddSuccessToastMessage(Messages.User.Update(updateUserViewModel.Email), new ToastrOptions { Title = "İşlem Başarılı" });

                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                          var validation = await validator.ValidateAsync(user);
                    
                        return View(new UpdateUserViewModel { Roles = roles });
                    }
                }
            }
            return NotFound();

        }
        [Authorize(Roles = $"{ConstRole.Topmanager}")]
        public async Task<IActionResult> Delete(Guid userId)
        {

            var result = await userService.DeleteUser(userId);
            if(result.IdentityResult.Succeeded)
            {
                toast.AddWarningToastMessage(Messages.User.Delete(result.Email), new ToastrOptions { Title = "İşlem Başarılı" });

                return RedirectToAction("Index", "User", new { Area = "Admin" });

            }
            else
            {
                foreach (var error in result.IdentityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Profile()
        {
           
            var result = await userService.GetuserProfile();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileViewModel userProfileViewModel)
        {
           
            if (ModelState.IsValid)
            {
                var r = await userService.UpdateUserProfile(userProfileViewModel);
                if(r == true)
                {
                 
                    toast.AddSuccessToastMessage("Profil güncellendi.", new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    var result = await userService.GetuserProfile();
                    toast.AddErrorToastMessage("Profil güncellemesi yapılamadı.", new ToastrOptions { Title = "İşlem Başarısız" });
                    return View(result);
                }
            }
            else
            {
                toast.AddErrorToastMessage("Bir hata oluştu.", new ToastrOptions { Title = "İşlem Başarısız" });
            }
            return View();
        
        }
    }
}
