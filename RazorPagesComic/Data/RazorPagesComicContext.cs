using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesComic.Models;

namespace RazorPagesComic.Data
{
    public class RazorPagesComicContext : DbContext
    {
        public RazorPagesComicContext (DbContextOptions<RazorPagesComicContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesComic.Models.Comic> Comic { get; set; } = default!;
    }
}
