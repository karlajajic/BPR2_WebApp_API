using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistProducts> WishlistProducts { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credentials>().ToTable("credentials");
            modelBuilder.Entity<CustomerProfile>().ToTable("customer_profiles");
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<SoldProduct>().ToTable("sold_products");
            modelBuilder.Entity<Wishlist>().ToTable("wishlists");
            modelBuilder.Entity<WishlistProducts>().ToTable("wishlist_products");
            modelBuilder.Entity<Newsletter>().ToTable("newsletters");
        }


        //PM> add-migration InitialMigration
        //Build started...
        //Build succeeded.
        //To undo this action, use Remove-Migration.
        //PM> Update-Database
        //Build started...
        //Build succeeded.
        //Done.
        //PM> 
    }
}
