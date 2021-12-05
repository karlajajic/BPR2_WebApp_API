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
        public DbSet<WishlistProduct> WishlistProducts { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProduct> StoreProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credentials>().ToTable("credentials");
            modelBuilder.Entity<CustomerProfile>().ToTable("customer_profiles");
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<SoldProduct>().ToTable("sold_products");
            modelBuilder.Entity<Wishlist>().ToTable("wishlists");
            modelBuilder.Entity<WishlistProduct>().ToTable("wishlist_products");
            modelBuilder.Entity<Newsletter>().ToTable("newsletters");
            modelBuilder.Entity<Review>().ToTable("reviews");
            modelBuilder.Entity<Store>().ToTable("stores");
            modelBuilder.Entity<StoreProduct>().ToTable("store_products");

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
