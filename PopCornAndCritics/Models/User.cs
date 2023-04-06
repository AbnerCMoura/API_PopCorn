using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PopCornAndCritics.Models;

public class User
{
    public int Id { get; set; }

    [Column]
    [Required]
    public string UserName { get; set; }


    [Column]
    [Required]
    public string Password { get; set; }


    [Column]
    [Required]
    public int Evals { get; set; }


    [Column]
    [Required]
    [EmailAddress]
    public string Email { get; set; }


    [Column]
    [Required]
    public string Bio { get; set; } = "";
}
