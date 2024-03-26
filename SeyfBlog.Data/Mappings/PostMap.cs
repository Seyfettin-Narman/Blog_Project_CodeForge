using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeyfBlog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeyfBlog.Data.Mappings
{
    internal class PostMap : IEntityTypeConfiguration<Post>
    {   //Post için SeedData kısmı
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(new Post
            {
                Id = Guid.NewGuid(),
                Title = "Back-End CodeForge Bootcamp",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse consectetur dolor non ex gravida, at.",
                CategoryId = Guid.Parse("2F935AC0-FC48-4404-8A3E-F4D092223E8E"),
                ImageId= Guid.Parse("18339C9C-0871-4F8F-8EE1-EAAF482B813D"),
                CreatedBy="Seyfettin",
                CreatedDate=DateTime.Now,
                Views=4,
                isActive=false,
                UserId = Guid.Parse("B35A3FD6-698F-4BB9-AF71-8C4E8478C2E4")
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "CodeRoots: Planting the Seeds of JavaScript",
                Content = "Curabitur cursus ullamcorper sapien, at fermentum elit finibus at. Nunc tristique nec sapien eu feugiat. Ut quis dictum turpis. Proin",
                CategoryId=Guid.Parse("9E139175-6C2D-4F87-B26B-F3FDAC76EF6D"),
                ImageId= Guid.Parse("026DD0D1-07F7-4F83-9324-D091CA7403F2"),
                CreatedBy = "Murat",
                CreatedDate = DateTime.Now,
                Views = 10,
                isActive = false,
                UserId = Guid.Parse("C1315BB8-4D09-450E-A549-8BA87D8FA228")
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "The Evolution of Avionics Networks From ARINC 429 to AFDX",
                Content = "Nullam eleifend, nisl vel molestie iaculis, metus lorem mollis mi, vitae interdum odio lorem id odio. Duis aliquet est orci.",
                CategoryId=Guid.Parse("2EDFFA17-0A93-4B0A-B8FB-7B1662F68611"),
                ImageId=Guid.Parse("9ED22153-C44E-4B44-84CD-072E889FB62C"),
                CreatedBy = "Seyfettin",
                CreatedDate = DateTime.Now,
                Views = 40,
                isActive = false,
                UserId = Guid.Parse("C1315BB8-4D09-450E-A549-8BA87D8FA228")
            }
            );
        }
    }
}
