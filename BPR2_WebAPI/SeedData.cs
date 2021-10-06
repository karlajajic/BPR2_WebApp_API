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
                context.SaveChanges();
            }
        }
    }
}
