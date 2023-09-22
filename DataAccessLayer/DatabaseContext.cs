using DataAccessLayer.Mapping;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DatabaseContext:DbContext
    {
        public DbSet<TBLBlog> TBLBlog { get; set; }
        public DbSet<TBLBlog> TBLCategories { get; set; }
        public DbSet<TBLBlog> TBLUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-N9NKOIQ\SQLEXPRESS;Database=BlogProject;Trusted_Connection=True;trustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MappingTBLBlog());
            modelBuilder.ApplyConfiguration(new MappingTBLCategories());
            modelBuilder.ApplyConfiguration(new MappingTBLUser());
        }
    }
}
