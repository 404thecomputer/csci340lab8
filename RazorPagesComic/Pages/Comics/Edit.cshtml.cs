using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesComic.Data;
using RazorPagesComic.Models;

namespace RazorPagesComic.Pages_Comics
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesComic.Data.RazorPagesComicContext _context;

        public EditModel(RazorPagesComic.Data.RazorPagesComicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Comic Comic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comic =  await _context.Comic.FirstOrDefaultAsync(m => m.Id == id);
            if (comic == null)
            {
                return NotFound();
            }
            Comic = comic;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Comic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComicExists(Comic.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ComicExists(int id)
        {
            return _context.Comic.Any(e => e.Id == id);
        }
    }
}
