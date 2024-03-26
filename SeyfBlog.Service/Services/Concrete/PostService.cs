using AutoMapper;
using Azure.Identity;
using Microsoft.AspNetCore.Http;
using SeyfBlog.Data.Units;
using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.Enums;
using SeyfBlog.Entity.ViewModels.Posts;
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
    public class PostService : IPostService
    {
        private readonly IUnit unit;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor accesor;
        private readonly IImageHelper image;
        private readonly ClaimsPrincipal _user;
        public PostService(IUnit unit, IMapper mapper, IHttpContextAccessor accesor, IImageHelper image)
        {
            this.unit = unit;
            this.mapper = mapper;
            this.accesor = accesor;
            this.image = image;
            _user = accesor.HttpContext.User;
        }

        public async Task CreatePost(AddPostViewModel addPostViewModel)
        {
            var userId = _user.GetLoginUserId();
            var userEmail = _user.GetLoginEmail();
            var uploadImage = await image.Upload(addPostViewModel.Title, addPostViewModel.ImageFile, ImageType.Post);
            Image img = new(uploadImage.FullName, addPostViewModel.ImageFile.ContentType, userEmail);
            await unit.GetRepository<Image>().Add(img);
            var post = new Post
            {
                Title = addPostViewModel.Title,
                CreatedBy = userEmail,
                UserId = userId,
                Content = addPostViewModel.Content,
                CategoryId = addPostViewModel.CategoryId,
                ImageId = img.Id,
            };
            await unit.GetRepository<Post>().Add(post);
            await unit.SaveAsync();
        }

        public async Task<List<PostViewModel>> GetAllPostsWithCategory()
        {
            var posts = await unit.GetRepository<Post>().GetAll(x => !x.isActive, x => x.Category);
            var map = mapper.Map<List<PostViewModel>>(posts);
            return map;
        }
        public async Task<PostViewModel> GetPostsWithCategory(Guid postId)
        {
            var post = await unit.GetRepository<Post>().Get(x => !x.isActive && x.Id == postId, x => x.Category, i => i.Image,x =>x.User);
            var map = mapper.Map<PostViewModel>(post);
            return map;
        }
        public async Task<string> UpdatePost(UpdatePostViewModel updatePostViewModel)
        {
            var userEmail = _user.GetLoginEmail();
            var post = await unit.GetRepository<Post>().Get(x => !x.isActive && x.Id == updatePostViewModel.Id, x => x.Category, i => i.Image);
           if(updatePostViewModel.imageFile != null)
            {
                image.Delete(post.Image.FileName);
                var uploadImage = await image.Upload(updatePostViewModel.Title, updatePostViewModel.imageFile, ImageType.Post);
                Image img = new(uploadImage.FullName, updatePostViewModel.imageFile.ContentType, userEmail);
                await unit.GetRepository<Image>().Add(img);
                post.ImageId = img.Id;
            }
            post.Title= updatePostViewModel.Title;
            post.Content= updatePostViewModel.Content;
            post.CategoryId= updatePostViewModel.CategoryId;
            post.ModifiedBy = userEmail;
            post.ModifiedDate = DateTime.Now;
            await unit.GetRepository<Post>().Update(post);
            await unit.SaveAsync();
            return post.Title;
        }
        public async Task<string> SeyfDelete(Guid postId)
        {
            var userEmail = accesor.HttpContext.User.GetLoginEmail();
            var post = await unit.GetRepository<Post>().GetByGuid(postId);
            post.isActive = true;
            post.DeletedDate=DateTime.Now;
            post.DeletedBy = userEmail;
            await unit.GetRepository<Post>().Update(post);
            await unit.SaveAsync();
            return post.Title;
        }

        public async Task<List<PostViewModel>> GetAllDeletedPosts()
        {
            var posts = await unit.GetRepository<Post>().GetAll(x => x.isActive, x => x.Category);
            var map = mapper.Map<List<PostViewModel>>(posts);
            return map;
        }
        public async Task<ListPostViewModel> GetAllByPaging(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var posts = categoryId == null ?
                await unit.GetRepository<Post>().GetAll(x => !x.isActive, x => x.Category, i => i.Image,x =>x.User) :
                await unit.GetRepository<Post>().GetAll(x => x.CategoryId == categoryId && !x.isActive, x => x.Category, i => i.Image, x => x.User);
            var sortedPosts = isAscending ?
                posts.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList() :
                posts.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ListPostViewModel
            {
                Posts = sortedPosts,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = posts.Count,
                isAscending = isAscending
            };
        }

            public async Task<string> UndoDelete(Guid postId)
        {
            var userEmail = accesor.HttpContext.User.GetLoginEmail();
            var post = await unit.GetRepository<Post>().GetByGuid(postId);
            post.isActive = false;
            post.DeletedDate = null;
            post.DeletedBy = null;
            await unit.GetRepository<Post>().Update(post);
            await unit.SaveAsync();
            return post.Title;
        }

        public async Task<ListPostViewModel> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var posts = await unit.GetRepository<Post>().GetAll(x => !x.isActive && (x.Title.Contains(keyword) || x.Content.Contains(keyword) || x.Category.Name.Contains(keyword)), x => x.Category, i => i.Image, x => x.User);
               
            var sortedPosts = isAscending ?
                posts.OrderBy(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList() :
                posts.OrderByDescending(x => x.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ListPostViewModel
            {
                Posts = sortedPosts,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = posts.Count,
                isAscending = isAscending
            };
        }
    }
}
