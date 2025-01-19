using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorGSH.Models;

namespace RazorGSH.Pages.Articles
{
    public class DetailsModel : PageModel
    {
        private readonly RazorGSH.Models.MyDbContext _context;

        public DetailsModel(RazorGSH.Models.MyDbContext context)
        {
            _context = context;

        }

        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Article.FirstOrDefaultAsync(m => m.Id == id);

            if (Article == null)
            {
                return NotFound();
            }
            ViewData["Category"] = "no category";
            foreach (var cat in _context.Category.ToList())
            {
                if (cat.Id == Article.CategoryId)
                {
                    ViewData["Category"] = cat.Name;
                    break;
                }
            }
            return Page();
        }
    }
}
