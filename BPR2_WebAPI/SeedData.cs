using BPR2_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR2_WebAPI
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                SeedProducts(context);
                SeedWishlists(context);
                SeedNewsletters(context);

                context.SaveChanges();
            }
        }

        private static void SeedProducts(DataContext context)
        {
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                new Product
                {
                    Name = "Cacao",
                    Barcode = 100988776,
                    Category = "Flavoure",
                    Brand = "Nestle",
                    Price = 15.5
                },
                new Product
                {
                    Name = "Chocolate",
                    Barcode = 123456789,
                    Category = "Swwets",
                    Brand = "Milka",
                    Price = 10.5
                },
                new Product
                {
                    Name = "Milk",
                    Barcode = 364758192,
                    Category = "Diary",
                    Brand = "Arla",
                    Price = 12
                },
                new Product
                {
                    Name = "Nutella",
                    Barcode = 129092837,
                    Category = "Sweets",
                    Brand = "Nutella",
                    Price = 25
                },
                new Product
                {
                    Name = "Green Tea",
                    Barcode = 144467829,
                    Category = "Tea",
                    Brand = "Harney & Sons",
                    Price = 18
                }
            );
        }

        private static void SeedWishlists(DataContext context)
        {
            if (context.Wishlists.Any())
            {
                return;  
            }

            context.Wishlists.AddRange(
                new Wishlist
                {
                    ProfileId = "3",
                    Name = "Lena healthy"
                },
                new Wishlist
                {
                    ProfileId = "3",
                    Name = "Lena chocolate"
                },
                new Wishlist
                {
                    ProfileId = "3",
                    Name = "Lena sodas"
                },
                new Wishlist
                {
                    ProfileId = "4",
                    Name = "Karla chocolate"
                },
                new Wishlist
                {
                    ProfileId = "4",
                    Name = "Karla sodas"
                }
            );
        }

        private static void SeedNewsletters(DataContext context)
        {
            if (context.Newsletters.Any())
            {
                return;   // DB has been seeded
            }

            context.Newsletters.AddRange(
                new Newsletter
                {
                    Title = "Chocolate on sale",
                    Details = "All chocolate on 20% on sale", 
                    ValidFrom = DateTime.Now, 
                    ValidTo = DateTime.Now.AddDays(12)
                },
                new Newsletter
                {
                    Title = "Wine on sale",
                    Details = "Red wine on 10% on sale",
                    ValidFrom = DateTime.Now,
                    ValidTo = DateTime.Now.AddDays(12)
                }
            );
        }


    }
}
