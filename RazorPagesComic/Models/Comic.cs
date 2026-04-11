using System.ComponentModel.DataAnnotations;

namespace RazorPagesComic.Models;

public class Comic
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int Issue { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Publisher { get; set; }
}