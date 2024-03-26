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
    public class RoleMap : IEntityTypeConfiguration<IdRole>
    {
        public void Configure(EntityTypeBuilder<IdRole> b)
        {
            b.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            b.ToTable("AspNetRoles");

            // A concurrency token for use with the optimistic concurrency checking
            b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            b.Property(u => u.Name).HasMaxLength(256);
            b.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            b.HasMany<IdUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            b.HasMany<IdRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            b.HasData(
                new IdRole
                {
                    Id = Guid.Parse("F4D0283B-3499-4189-A720-62B0F778DE6B"),
                    Name = "Topmanager",
                    NormalizedName = "TOPMANAGER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdRole
                {
                    Id = Guid.Parse("08DD1239-F563-44E7-A389-B692DA355CE8"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdRole
                {
                    Id = Guid.Parse("B48AA289-340A-4694-9F72-C11E5D95C581"),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );
        }
    }
}
