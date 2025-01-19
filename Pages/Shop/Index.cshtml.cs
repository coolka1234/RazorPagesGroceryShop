using RazorGSH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorGSH.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private readonly MyDbContext _context;

        public IndexModel(MyDbContext context)
        {
            _context = context;
        }

        public List<Article> Articles { get; set; }
        public List<Category> Categories { get; set; }

       /* [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }*/

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Articles = await _context.Article.ToListAsync();

            if (id != null)
            {
                
                Articles = Articles.Where(a => a.CategoryId == id).ToList();
            }

            Categories = await _context.Category.ToListAsync();

            return Page();
        }
    }
}
