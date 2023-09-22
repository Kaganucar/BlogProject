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
    public class MappingTBLCategories : IEntityTypeConfiguration<TBLCategories>
    {
        public void Configure(EntityTypeBuilder<TBLCategories> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.CategoryName).HasMaxLength(50);

            builder.HasMany(x => x.TBLBlog).WithOne(x => x.TBLCategory).HasForeignKey(x => x.CategoriesId);

            builder.ToTable("TBLCategories");
        }
    }
}
