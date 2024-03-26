using SeyfBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Entity.ViewModels.Posts
{
    public class ListPostViewModel
    {
        public IList<Post>  Posts { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual int PageSize { get; set; } = 3;
        public virtual int CurrentPage { get; set; } = 1;
        public virtual int TotalCount { get; set; }
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
        public virtual bool Previous => CurrentPage > 1;
        public virtual bool Next => CurrentPage < TotalPages;
        public virtual bool isAscending { get; set; }
    }
}
