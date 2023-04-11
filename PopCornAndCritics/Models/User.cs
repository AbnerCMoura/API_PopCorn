using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PopCornAndCritics.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int Evals { get; set; }
    public string Email { get; set; }
    public string ImageUrl { get; set; }
    public string Bio { get; set; } = "";
}
