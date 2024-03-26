using SeyfBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Data.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntityBase, new()
    {
        Task Add(T entity);

        //Liste döndürmek için
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includePorperties);

        //Tek bir değer döndürmek için

        Task<T> Get(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includePorperties);

        //id ye göre varlığı bulmak için
        Task<T> GetByGuid(Guid id);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task<int> Count(Expression<Func<T, bool>> predicate = null);

    }
}
