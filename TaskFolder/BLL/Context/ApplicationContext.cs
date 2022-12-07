using DL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category_Product>().HasKey(sc => new { sc.ProductId, sc.CategoryId });
            modelBuilder.Entity<Category_Product>().HasOne(p => p.product).WithMany(cp => cp.Product_Categories).HasForeignKey(pkey => pkey.ProductId);
            modelBuilder.Entity<Category_Product>().HasOne(p => p.category).WithMany(cp => cp.Product_Categories).HasForeignKey(pkey => pkey.CategoryId);
           

        }
        public DbSet<Category> TblCategory { get; set; }

        public DbSet<Product> TblProduct { get; set; }

        public DbSet<Category_Product> TblCategory_Product { get; set; }

        public DbSet<UserInfo> TblUsers { get; set; }
    }
}
