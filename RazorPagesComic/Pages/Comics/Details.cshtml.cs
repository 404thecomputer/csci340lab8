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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesComic.Data.RazorPagesComicContext _context;

        public DetailsModel(RazorPagesComic.Data.RazorPagesComicContext context)
        {
            _context = context;
        }

        public Comic Comic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic = await _context.Comic.FirstOrDefaultAsync(m => m.Id == id);

            if (comic is not null)
            {
                Comic = comic;

                return Page();
            }

            return NotFound();
        }
    }
}
