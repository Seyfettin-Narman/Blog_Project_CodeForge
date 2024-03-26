using Microsoft.EntityFrameworkCore;
using SeyfBlog.Data.Context;
using SeyfBlog.Data.Repositories.Abstract;
using SeyfBlog.Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Data.Units
{
    public class Unit : IUnit
    {
        private readonly SeyfBlogDbContext SeyfDbContext;

        public Unit(SeyfBlogDbContext SeyfDbContext)
        {
            this.SeyfDbContext = SeyfDbContext;
        }
        public async ValueTask DisposeAsync()
        {
            await SeyfDbContext.DisposeAsync();
        }

        public int Save()
        {
            return SeyfDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await SeyfDbContext.SaveChangesAsync();
        }

        IRepository<T> IUnit.GetRepository<T>()
        {
            return new Repository<T>(SeyfDbContext);
        }
    }
}
