using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeyfBlog.Data.Repositories.Abstract;
using SeyfBlog.Data.Repositories.Concrete;
using SeyfBlog.Data.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Data.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection LoadDataExtensions(this IServiceCollection services,IConfiguration config)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnit, Unit>();
            return services;
        }
    }
}
