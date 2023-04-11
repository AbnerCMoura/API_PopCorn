using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PopCornAndCritics.Models.DTOs;

public class UserDTO
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string Bio { get; set; }
}
