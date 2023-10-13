using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPagesLego.Models;

public class Lego
{
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 5)]
    [Required]
    public string? Title { get; set; }

    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }

    [Display(Name = "Piece Count")]
    public int PieceCount { get; set; }

    [Display(Name = "Release Price")]
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal ReleasePrice { get; set; }
}