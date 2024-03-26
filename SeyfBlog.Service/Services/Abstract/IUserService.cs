using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.Services.Abstract
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAllUsers();
        Task<List<IdRole>> GetAllRoles();
        Task<IdentityResult> CreateUser(AddUserViewModel addUserViewModel);
        Task<IdUser> GetIdUserByGuid(Guid userId);
        Task<IdentityResult> UpdateUser(UpdateUserViewModel updateUserViewModel);
        Task<string> GetUserRole(IdUser user);
        Task<(IdentityResult IdentityResult,string? Email)> DeleteUser(Guid userId);
        Task<UserProfileViewModel> GetuserProfile();
        Task<bool> UpdateUserProfile(UserProfileViewModel userProfileViewModel);
    }
}
