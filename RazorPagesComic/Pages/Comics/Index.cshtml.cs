using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesComic.Data;
using RazorPagesComic.Models;

namespace RazorPagesComic.Pages_Comics
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesComic.Data.RazorPagesComicContext _context;

        public IndexModel(RazorPagesComic.Data.RazorPagesComicContext context)
        {
            _context = context;
        }

        public IList<Comic> Comic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Comic = await _context.Comic.ToListAsync();
        }
    }
}
