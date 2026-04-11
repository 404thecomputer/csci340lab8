using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesComic.Models;

public class Comic
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int Issue { get; set; }
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Publisher { get; set; }
}