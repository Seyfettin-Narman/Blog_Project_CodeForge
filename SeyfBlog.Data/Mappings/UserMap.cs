using Microsoft.AspNetCore.Identity;
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
    public class UserMap : IEntityTypeConfiguration<IdUser>
    {
        public void Configure(EntityTypeBuilder<IdUser> b)
        {
            b.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            b.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            b.Property(u => u.UserName).HasMaxLength(256);
            b.Property(u => u.NormalizedUserName).HasMaxLength(256);
            b.Property(u => u.Email).HasMaxLength(256);
            b.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            b.HasMany<IdUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            b.HasMany<IdUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            b.HasMany<IdUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany<IdUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            var topmanager = new IdUser
            {
                Id = Guid.Parse("B35A3FD6-698F-4BB9-AF71-8C4E8478C2E4"),
                UserName = "topmanager@gmail.com",
                NormalizedUserName = "TOPMANAGER@GMAIL.COM",
                FirstName = "Murat",
                lastName = "Narman",              
                Email = "topmanager@gmail.com",
                NormalizedEmail = "TOPMANAGER@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "+905457658945",
                PhoneNumberConfirmed = true,
                ImageId= Guid.Parse("18339C9C-0871-4F8F-8EE1-EAAF482B813D"),

            };
            topmanager.PasswordHash = CreateHash(topmanager, "199220");
            var admin = new IdUser
            {
                Id = Guid.Parse("C1315BB8-4D09-450E-A549-8BA87D8FA228"),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                FirstName = "Seyfettin",
                lastName = "Narman", 
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "+905457652945",
                PhoneNumberConfirmed = true,
                ImageId = Guid.Parse("18339C9C-0871-4F8F-8EE1-EAAF482B813D"),

            };
            admin.PasswordHash = CreateHash(admin, "905684");
            b.HasData(topmanager, admin);
        }
        private string CreateHash (IdUser user , string password)
        {
            var passHash = new PasswordHasher<IdUser>();
            return passHash.HashPassword(user, password);
        }
    }
}
