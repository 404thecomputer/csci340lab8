using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesComic.Data;
using RazorPagesComic.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Publishers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ComicPublisher { get; set; }

        public async Task OnGetAsync()
        {
            // <snippet_search_linqQuery>
            IQueryable<string> publisherQuery = from c in _context.Comic
                                            orderby c.Publisher
                                            select c.Publisher;
            // </snippet_search_linqQuery>

            var comics = from c in _context.Comic
                        select c;

            if (!string.IsNullOrEmpty(SearchString))
            {
                comics = comics.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ComicPublisher))
            {
                comics = comics.Where(x => x.Publisher == ComicPublisher);
            }

            // <snippet_search_selectList>
            Publishers = new SelectList(await publisherQuery.Distinct().ToListAsync());
            // </snippet_search_selectList>
            Comic = await comics.ToListAsync();
        }
    }
}
