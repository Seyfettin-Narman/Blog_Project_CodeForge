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
    public class UserRoleMap : IEntityTypeConfiguration<IdUserRole>
    {
        public void Configure(EntityTypeBuilder<IdUserRole> b)
        {
            b.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            b.ToTable("AspNetUserRoles");
            b.HasData(new IdUserRole
            {
                UserId = Guid.Parse("B35A3FD6-698F-4BB9-AF71-8C4E8478C2E4"),
                RoleId = Guid.Parse("F4D0283B-3499-4189-A720-62B0F778DE6B")
            },
            new IdUserRole
            {
                UserId = Guid.Parse("C1315BB8-4D09-450E-A549-8BA87D8FA228"),
                RoleId = Guid.Parse("08DD1239-F563-44E7-A389-B692DA355CE8")
            });
        }
    }
}
