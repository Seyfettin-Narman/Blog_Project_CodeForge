using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeyfBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Data.Mappings
{   //Image için SeedData kısmı
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(
          
                new Image 
                { 
                    Id= Guid.Parse("18339C9C-0871-4F8F-8EE1-EAAF482B813D"),
                    FileName="images/seyfettin",
                    FileType="jpg",
                    CreatedBy="Seyfettin",
                    CreatedDate=DateTime.Now,
                    isActive=true
                },
                new Image 
                { 
                    Id = Guid.Parse("026DD0D1-07F7-4F83-9324-D091CA7403F2"), 
                    FileName = "images/murat", 
                    FileType = "jpg", 
                    CreatedBy = "Murat", 
                    CreatedDate = DateTime.Now, 
                    isActive = true 
                },
                new Image 
                { 
                    Id = Guid.Parse("9ED22153-C44E-4B44-84CD-072E889FB62C"), 
                    FileName = "images/murat", 
                    FileType = "jpg", 
                    CreatedBy = "Murat", 
                    CreatedDate = DateTime.Now, 
                    isActive = true 
                }
            );
        }
    }
}
