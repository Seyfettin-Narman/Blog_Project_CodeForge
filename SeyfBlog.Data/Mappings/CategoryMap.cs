using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeyfBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Data.Mappings
    //Kategori için SeedData kısmı
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                   new Category 
                   { 
                      Id = Guid.Parse("2F935AC0-FC48-4404-8A3E-F4D092223E8E"), 
                      Name = "Yazılım", 
                      CreatedBy = "Seyfettin", 
                      CreatedDate = DateTime.Now, 
                      isActive = false 
                   },
                   new Category
                   { 
                       Id = Guid.Parse("9E139175-6C2D-4F87-B26B-F3FDAC76EF6D"), 
                       Name = "Yazılım/Bilişim", 
                       CreatedBy = "Murat",
                       CreatedDate = DateTime.Now, 
                       isActive = false 
                   },
                   new Category 
                   { 
                       Id = Guid.Parse("2EDFFA17-0A93-4B0A-B8FB-7B1662F68611"), 
                       Name = "Donanım", 
                       CreatedBy = "Christian M. Fuchs", 
                       CreatedDate = DateTime.Now, 
                       isActive = false 
                   }
                );
        }
    }
}
