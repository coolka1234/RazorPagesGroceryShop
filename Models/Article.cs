using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RazorGSH.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get; set; }
        public string PriceAsString { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Promotion")]
        public bool IsPromo { get; set; }
    }
}
