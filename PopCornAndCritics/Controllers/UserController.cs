using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PopCornAndCritics.Data;
using PopCornAndCritics.Models;

namespace PopCornAndCritics.Controllers;

public class UserController : ControllerBase
{

    public readonly Context _context;

    public UserController(Context context)
    {
        _context = context;
    }

    //Register new user
    [HttpPost("/user/register")]
    public async Task<ActionResult<User>> Register([FromBody] UserDTO userDTO)
    {
        var validator = new UserDTOValidator();
        var validationResult = await validator.ValidateAsync(userDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var user = new User
        {
            UserName = userDTO.UserName,
            Email = userDTO.Email,
            Password = userDTO.Password,
        };
        
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    //Update user biografy
    [HttpPut("{id}")]
    public async Task<ActionResult> AddBio(int id, [FromBody] string bio )
    {
        var user = await _context.User.FindAsync(id);

        if(user == null)
        {
            return NotFound();
        }

        user.Bio = bio;

        _context.User.Update(user);
        await _context.SaveChangesAsync();

        return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser(int id)
    {

        var user = await _context.User.FindAsync(id);

        if(user == null)
        {
            return NotFound();
        }

        user.Password = null;

        return Ok(user);
    }
}
