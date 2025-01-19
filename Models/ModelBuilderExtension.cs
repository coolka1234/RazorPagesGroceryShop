using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace RazorGSH.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            var categories = new List<Category>
            {
            new Category()
            {
                Id = 1,
                Name = "Vegetables",
            }, new Category()
            {
                Id = 2,
                Name = "Fruit",
            }, new Category()
            {
                Id = 3,
                Name = "Meat",
            }, new Category()
            {
                Id = 4,
                Name = "Dairy",
            }, new Category() {
                Id = 5,
                Name = "Sweets"
            }, new Category() {
                Id = 6,
                Name = "Breadstuff"
            }
            };

            var articles = new List<Article>
            {
                 new Article()
                {
                    Id = 1,
                    Name = "Apple",
                    Price = 2.5F,
                    PriceAsString = "2.5",
                    CategoryId = 2,
                    ImagePath = "image/apple.jpg"
                }, new Article()
                {
                    Id = 2,
                    Name = "Carrot",
                    Price = 3.0F,
                    PriceAsString = "3.0",
                    CategoryId = 4,
                    ImagePath = "image/carrot.png"
                }, new Article()
                {
                    Id = 3,
                    Name = "Milk",
                    Price = 4.5F,
                    PriceAsString = "4.5",
                    CategoryId = 2,
                    ImagePath = "image/milk.jpg"
                }
            };


            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Article>().HasData(articles);

            Console.WriteLine("Data added to modelBuilder.");
        }
    }
}
