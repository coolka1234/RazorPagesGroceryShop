using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorGSH.Models;
using System.IO;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace RazorGSH.Pages.Articles
{
    public class DeleteModel : PageModel
    {
        private readonly RazorGSH.Models.MyDbContext _context;

        private readonly IHostingEnvironment _hostingEnvironment;

        public DeleteModel(RazorGSH.Models.MyDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;

            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Article.FindAsync(id);

            if (Article != null)
            {
                _context.Article.Remove(Article);
                if (Article.ImagePath != null)
                {
                    var fullPath = Path.Combine(_hostingEnvironment.WebRootPath, Article.ImagePath);
                    if (System.IO.File.Exists(fullPath) && Article.ImagePath != "image/noimage.jpg")
                    {
                        System.IO.File.Delete(fullPath);
                    }
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
