
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PopCornAndCritics.Models;

[Table("Movie")]
public class Movie
{
    public int Id { get; set; }

    [Column]
    [Required]
    public string Title { get; set; }

    [Column]
    [Required]
    public string Description { get; set; }

    [Column]
    [Required]
    public string Genre { get; set; }

    [Column]
    [Required]
    public string Duration { get; set; }

    [Column]
    [Required]
    public double Rating { get; set; }

    [Column]
    [Required]
    [Url]
    public string ImageUrl { get; set; }
}
