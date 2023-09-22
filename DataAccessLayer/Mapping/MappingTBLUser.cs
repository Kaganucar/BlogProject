using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    public class MappingTBLUser : IEntityTypeConfiguration<TBLUser>
    {
        public void Configure(EntityTypeBuilder<TBLUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x=>x.Name).HasMaxLength(50);
            builder.Property(x=>x.Email).HasMaxLength(50);
            builder.Property(x=>x.Password).HasMaxLength(50);
            builder.Property(x=>x.Roles).HasMaxLength(50);

            builder.ToTable("TBLUser");
        }
    }
}
