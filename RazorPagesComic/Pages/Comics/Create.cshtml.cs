using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesComic.Data;
using RazorPagesComic.Models;

namespace RazorPagesComic.Pages_Comics
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesComic.Data.RazorPagesComicContext _context;

        public CreateModel(RazorPagesComic.Data.RazorPagesComicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Comic Comic { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Comic.Add(Comic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
