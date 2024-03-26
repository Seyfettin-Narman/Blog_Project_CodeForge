using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeyfBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Data.Context
{
    public class SeyfBlogDbContext : IdentityDbContext<IdUser,IdRole,Guid,IdUserClaim,IdUserRole,IdUserLogin,IdRoleClaim,IdUserToken>
    {


        public SeyfBlogDbContext()
        {

        }
        public SeyfBlogDbContext(DbContextOptions<SeyfBlogDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
