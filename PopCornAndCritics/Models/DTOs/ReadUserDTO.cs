namespace PopCornAndCritics.Models.DTOs;

public class ReadUserDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }

    public string Email { get; set; }

    public int Evals { get; set; }

    public string Bio { get; set; }

    public string imageUrl { get; set; }

}
