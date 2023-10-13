using System.ComponentModel.DataAnnotations;

namespace RazorPagesLego.Models;

public class Lego
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public int PieceCount { get; set; }
    public decimal ReleasePrice { get; set; }
}