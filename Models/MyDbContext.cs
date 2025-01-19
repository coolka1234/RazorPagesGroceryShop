using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace RazorGSH.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("on model creating executing");
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        public void UpdateArticle(DbContext context, Article article)
        {
            var existingArticle = context.Set<Article>().FirstOrDefault(a => a.Id == article.Id);

            if (existingArticle != null)
            {
                existingArticle.Name = article.Name;
                existingArticle.PriceAsString = article.PriceAsString;
                existingArticle.CategoryId = article.CategoryId;

                existingArticle.Price = article.Price;
                existingArticle.IsPromo = article.IsPromo;


                context.SaveChanges();
            }
        }

    }
}
