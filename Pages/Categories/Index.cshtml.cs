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
    public class IndexModel : PageModel
    {
        private readonly RazorGSH.Models.MyDbContext _context;

        public IndexModel(RazorGSH.Models.MyDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
