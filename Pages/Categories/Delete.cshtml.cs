using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorGSH.Models;

namespace RazorGSH.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly RazorGSH.Models.MyDbContext _context;

        public DeleteModel(RazorGSH.Models.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.Id == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FindAsync(id);

            var otherCategory = _context.Category.FirstOrDefault(c => c.Name == "Others");

            if (otherCategory != null)
            {
                foreach (var art in _context.Article.Where(a => a.CategoryId == id).ToList())
                {
                    art.CategoryId = otherCategory.Id;
                }
            }
            else
            {
                _context.Article.RemoveRange(_context.Article.Where(a => a.CategoryId == id));
            }

            if (Category != null)
            {
                _context.Category.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
