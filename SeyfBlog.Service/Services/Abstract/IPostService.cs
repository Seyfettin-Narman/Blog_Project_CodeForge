using SeyfBlog.Entity.Entities;
using SeyfBlog.Entity.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.Services.Abstract
{
    public interface IPostService
    {
        Task<List<PostViewModel>> GetAllPostsWithCategory();
        Task CreatePost(AddPostViewModel addPostViewModel);
        Task<PostViewModel> GetPostsWithCategory(Guid postId);
        Task<string> UpdatePost(UpdatePostViewModel updatePostViewModel);
        Task<string> SeyfDelete(Guid postId);
        Task<List<PostViewModel>> GetAllDeletedPosts();
        Task<string> UndoDelete(Guid postId);
        Task<ListPostViewModel> GetAllByPaging(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false);
        Task<ListPostViewModel> Search(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false);


    }
}
