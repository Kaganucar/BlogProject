using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    public class MappingTBLBlog : IEntityTypeConfiguration<TBLBlog>
    {
        public void Configure(EntityTypeBuilder<TBLBlog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.BlogName).HasMaxLength(50);
            builder.Property(x => x.Author).HasMaxLength(50);
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Explanation).HasMaxLength(1000);
            builder.Property(x => x.Images).HasMaxLength(50);

            builder.HasOne(x=> x.TBLCategory).WithMany(x=> x.TBLBlog).HasForeignKey(x=>x.CategoriesId);

            builder.ToTable("TBLBlog");

        }
    }
}
