using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeyfBlog.Service.FluentValidations;
using SeyfBlog.Service.Helpers.Images;
using SeyfBlog.Service.Services.Abstract;
using SeyfBlog.Service.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Service.Extensions
{
    public static  class ServiceExtensions
    {
        public static IServiceCollection LoadServiceExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddAutoMapper(assembly);
            services.AddControllersWithViews().AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<PostValidator>();
                options.DisableDataAnnotationsValidation = true;
                options.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }  
    }
}
