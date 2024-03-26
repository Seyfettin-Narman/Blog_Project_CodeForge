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
    public class UserTokenMap : IEntityTypeConfiguration<IdUserToken>
    {
        public void Configure(EntityTypeBuilder<IdUserToken> b)
        {
            b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            // Limit the size of the composite key columns due to common DB restrictions
            b.Property(t => t.LoginProvider);
            b.Property(t => t.Name);

            // Maps to the AspNetUserTokens table
            b.ToTable("AspNetUserTokens");
        }
    }
}
