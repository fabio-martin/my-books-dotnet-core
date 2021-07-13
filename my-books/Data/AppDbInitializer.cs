using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books
                        .AddRange(
                            new Book()
                            {
                                Title = "1st Book Title",
                                Description = "1st book description",
                                IsRead = true,
                                DateRead = DateTime.Now.AddDays(-10),
                                Rate = 4,
                                Genre = "Biography",
                                Author = "First Author",
                                CoverUrl = "https...",
                                DateAdded = DateTime.Now
                            }, new Book()
                            {
                                Title = "2st Book Title",
                                Description = "2st book description",
                                IsRead = false,
                                Genre = "Biography",
                                Author = "First Author",
                                CoverUrl = "https...",
                                DateAdded = DateTime.Now
                            }
                        );

                    context.SaveChanges();
                }
            }
        }
    }

}