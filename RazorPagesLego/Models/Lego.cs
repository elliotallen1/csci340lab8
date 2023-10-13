using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPagesLego.Models;

public class Lego
{
    public int Id { get; set; }
    public string? Title { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "Piece Count")]
    public int PieceCount { get; set; }

    [Display(Name = "Release Price")]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ReleasePrice { get; set; }
}