using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorGSH.Models;

namespace RazorGSH.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly RazorGSH.Models.MyDbContext _context;

        public IndexModel(RazorGSH.Models.MyDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            Article = await _context.Article.ToListAsync();
            //ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["Categories"] = await _context.Category.ToListAsync();
        }
    }
}
