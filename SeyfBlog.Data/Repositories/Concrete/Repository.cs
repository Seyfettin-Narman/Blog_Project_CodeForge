using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SeyfBlog.Core.Entities;
using SeyfBlog.Data.Context;
using SeyfBlog.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Data.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T :class, IEntityBase, new()
    {
        private readonly SeyfBlogDbContext seyfDbContext;

        public Repository(SeyfBlogDbContext seyfDbContext)
        {
            this.seyfDbContext = seyfDbContext;
        }
        private DbSet<T> SeyfTable { get => seyfDbContext.Set<T>(); }
        public async Task Add(T entity)
        {
            await SeyfTable.AddAsync(entity);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await SeyfTable.AnyAsync(predicate);
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate = null)
        {
            return await SeyfTable.CountAsync(predicate);
        }

        public async Task Delete(T entity)
        {
            await Task.Run(() =>SeyfTable.Remove(entity) );
          
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includePorperties)
        {
            IQueryable<T> query = SeyfTable;
            query = query.Where(predicate);
            if (includePorperties.Any())
            {
                foreach (var p in includePorperties)
                {
                    query = query.Include(p);
                }
            }
            return await query.SingleAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T,bool>> predicate = null, params Expression<Func<T, object>>[] includePorperties)
        {
            IQueryable<T> query = SeyfTable;
            if(predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includePorperties.Any())
            {
                foreach(var p in includePorperties)
                {
                    query = query.Include(p);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByGuid(Guid id)
        {
            return await SeyfTable.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            await Task.Run(() =>  SeyfTable.Update(entity) );
            return entity;
        }
    }

}
