using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CountryApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CountryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CountryContext>>()))
            {

                if (context.CountryItems.Any())
                {
                    return;
                }
                context.CountryItems.AddRange(
                    new CountryItem
                    {
                        Name = "Poland",
                        CapitalCity = "Warsaw",
                        Language = "Polish",
                        Currency = "PLN"
                    },
                    new CountryItem
                    {
                        Name = "USA",
                        CapitalCity = "Washington",
                        Language = "English",
                        Currency = "USD"
                    },
                    new CountryItem
                    {
                        Name = "Japan",
                        CapitalCity = "Tokyo",
                        Language = "Japanese",
                        Currency = "JPY"
                    },
                    new CountryItem
                    {
                        Name = "France",
                        CapitalCity = "Paris",
                        Language = "French",
                        Currency = "EUR"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}