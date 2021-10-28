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
                SeedCredentials(context);
                SeedCustomerProfiles(context);
                SeedWishlists(context);

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
                    Name = "Milka-milk chocolate",
                    Price = 10.5
                },
                new Product
                {
                    Name = "Milka-dark chocolate",
                    Price = 11.5
                },
                new Product
                {
                    Name = "Milka-wallnut chocolate ",
                    Price = 12
                }
            );
        }

        private static void SeedCredentials(DataContext context)
        {
            if (context.Credentials.Any())
            {
                return;   
            }

            context.Credentials.AddRange(
                new Credentials
                {
                    Code = 1142016674416790,
                    IsEmployee = true
                },
                new Credentials
                {
                    Code = 8435528168398317,
                    IsEmployee = true
                },
                new Credentials
                {
                    Code = 6171645260387105,
                    IsEmployee = false
                },
                new Credentials
                {
                    Code = 4271733177659343,
                    IsEmployee = false
                }
            );
        }

        private static void SeedCustomerProfiles(DataContext context)
        {
            if (context.CustomerProfiles.Any())
            {
                return;
            }

            context.CustomerProfiles.AddRange(
                new CustomerProfile
                {
                    ProfileId = 3,
                    Username = "LenaB"
                },
                new CustomerProfile
                {
                    ProfileId = 4,
                    Username = "KarlaJ"
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
                    ProfileId = 3,
                    Name = "Lena healthy"
                },
                new Wishlist
                {
                    ProfileId = 3,
                    Name = "Lena chocolate"
                },
                new Wishlist
                {
                    ProfileId = 3,
                    Name = "Lena sodas"
                },
                new Wishlist
                {
                    ProfileId = 4,
                    Name = "Karla chocolate"
                },
                new Wishlist
                {
                    ProfileId = 4,
                    Name = "Karla sodas"
                }
            );
        }


    }
}
