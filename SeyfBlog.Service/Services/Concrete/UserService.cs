using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SeyfBlog.Data.Units;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.Enums;
using SeyfBlog.Entity.ViewModels.Users;
using SeyfBlog.Service.Extensions;
using SeyfBlog.Service.Helpers.Images;
using SeyfBlog.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUnit unit;
        private readonly UserManager<IdUser> userManager;
        private readonly RoleManager<IdRole> roleManager;
        private readonly IHttpContextAccessor accesor;
        private readonly ClaimsPrincipal _user;
        private readonly SignInManager<IdUser> signInManager;
        private readonly IImageHelper imageHelper;

        public UserService(UserManager<IdUser> userManager, IHttpContextAccessor accesor, IImageHelper imageHelper, SignInManager<IdUser> signInManager, RoleManager<IdRole> roleManager, IUnit unit, IMapper mapper)
        {
            this.unit = unit;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.accesor = accesor;
            this._user = accesor.HttpContext.User;
            this.imageHelper = imageHelper;

        }

        public async Task<IdentityResult> CreateUser(AddUserViewModel addUserViewModel)
        {
            var map = mapper.Map<IdUser>(addUserViewModel);
            map.UserName = addUserViewModel.Email;
            var r = await userManager.CreateAsync(map, string.IsNullOrEmpty(addUserViewModel.Password) ? "" : addUserViewModel.Password);
            if (r.Succeeded)
            {
                var findRole = await roleManager.FindByIdAsync(addUserViewModel.RoleId.ToString());

                await userManager.AddToRoleAsync(map, findRole.ToString());
                return r;
            }
            else
            {
                return r;
            }

        }

        public async Task<(IdentityResult IdentityResult, string? Email)> DeleteUser(Guid userId)
        {
            var user = await GetIdUserByGuid(userId);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return (result, user.Email);
            }
            else
            {
                return (result, null);
            }

        }

        public async Task<List<IdRole>> GetAllRoles()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserViewModel>>(users);
            foreach (var user in map)
            {
                var u = await userManager.FindByIdAsync(user.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(u));
                user.Role = role;
            }
            return map;
        }

        public async Task<IdUser> GetIdUserByGuid(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<string> GetUserRole(IdUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user));
        }

        public async Task<IdentityResult> UpdateUser(UpdateUserViewModel updateUserViewModel)
        {
            var user = await GetIdUserByGuid(updateUserViewModel.Id);
            var userRole = await GetUserRole(user);
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {

                await userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await roleManager.FindByIdAsync(updateUserViewModel.RoleId.ToString());
                await userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
            {
                return result;
            }
        }
        public async Task<UserProfileViewModel> GetuserProfile()
        {
            var userId = _user.GetLoginUserId();
            var userWithImage = await unit.GetRepository<IdUser>().Get(x => x.Id == userId, x => x.Image);
            var map = mapper.Map<UserProfileViewModel>(userWithImage);
            map.Image.FileName = userWithImage.Image.FileName;
            return map;
        }
        public async Task<bool> UpdateUserProfile(UserProfileViewModel userProfileViewModel)
        {
            var userId = _user.GetLoginUserId();
            var user = await GetIdUserByGuid(userId);
            var isVerified = await userManager.CheckPasswordAsync(user, userProfileViewModel.CurrentPassword);
            if (isVerified && userProfileViewModel.NewPassword != null && userProfileViewModel.Photo != null)
            {
                var result = await userManager.ChangePasswordAsync(user, userProfileViewModel.CurrentPassword, userProfileViewModel.NewPassword);
                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.PasswordSignInAsync(user, userProfileViewModel.NewPassword, true, false);
                    user.FirstName = userProfileViewModel.FirstName; ;
                    user.lastName = userProfileViewModel.LastName;
                    user.PhoneNumber = userProfileViewModel.PhoneNumber;
                    if(userProfileViewModel.Photo != null)
                    {
                        var imgUpload = await imageHelper.Upload($"{userProfileViewModel.FirstName}{userProfileViewModel.LastName}", userProfileViewModel.Photo, ImageType.User);
                        Image img = new(imgUpload.FullName, userProfileViewModel.Photo.ContentType, user.Email);
                        await unit.GetRepository<Image>().Add(img);
                        user.ImageId = img.Id;
                    }

                    await userManager.UpdateAsync(user);
                    await unit.SaveAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (isVerified)
            {
                await userManager.UpdateSecurityStampAsync(user);
                user.FirstName = userProfileViewModel.FirstName;
                user.lastName = userProfileViewModel.LastName;
                user.PhoneNumber = userProfileViewModel.PhoneNumber;
                await userManager.UpdateAsync(user);
                if (userProfileViewModel.Photo != null)
                {
                    var imgUpload = await imageHelper.Upload($"{userProfileViewModel.FirstName}{userProfileViewModel.LastName}", userProfileViewModel.Photo, ImageType.User);
                    Image img = new(imgUpload.FullName, userProfileViewModel.Photo.ContentType, user.Email);
                    await unit.GetRepository<Image>().Add(img);
                    user.ImageId = img.Id;
                }
                await userManager.UpdateAsync(user);
                await unit.SaveAsync();
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
