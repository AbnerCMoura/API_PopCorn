using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopCornAndCritics.Data;
using PopCornAndCritics.Models;
using PopCornAndCritics.Models.DTOs;
using PopCornAndCritics.Models.Validators;

namespace PopCornAndCritics.Controllers;

public class UserController : ControllerBase
{

    public readonly Context _context;
    public readonly IMapper _mapper;

    public UserController(Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

        var _user = _context.User.FirstOrDefaultAsync(x => x.Email == userDTO.Email);

        if (_user != null)
        {
            return BadRequest("Usuário já existe");
        }

        var user = new User
        {
            UserName = userDTO.UserName,
            Email = userDTO.Email,
            Password = userDTO.Password,
        };

        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
        return Ok(userDTO);
    }

    [HttpPost("/user/sigin")]
    public async Task<ActionResult<UserDTO>> SigIn([FromBody] UserSigInDTO user )
    {
        var validator = new UserSigIntValidator();
        var validatorResult = await validator.ValidateAsync(user);

        if (!validatorResult.IsValid)
        {
            return BadRequest(validatorResult.Errors);
        }

        var _user = await _context.User.FirstOrDefaultAsync(x => x.Email == user.Email);

        if (_user == null)
        {
            return BadRequest();
        }

        var resLogin = _mapper.Map<ReadUserDTO>(_user);

        return Ok(resLogin);
    }

    //Update user 
    [HttpPatch("/user/update/{id}")]
    public async Task<ActionResult> UpdateUser (int id, [FromBody] JsonPatchDocument<UpdateDTO> patch)
    {
        var user = await _context.User.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        var updateUser = _mapper.Map<UpdateDTO>(user);

        patch.ApplyTo(updateUser);
        _mapper.Map(updateUser, user);

        await _context.SaveChangesAsync();
        
        return Ok(updateUser);
    }
    

    [HttpGet("/user/{id}")]
    public async Task<ActionResult> GetUser(int id)
    {

        var user = await _context.User.FindAsync(id);

        if(user == null)
        {
            return NotFound();
        }

        var _user = _mapper.Map<ReadUserDTO>(user);


        return Ok(_user);
    }

    [HttpGet("user/all")]
    public ActionResult<IEnumerable<ReadUserDTO>> GetAll()
    {
        return _mapper.Map<List<ReadUserDTO>>(_context.User);
    }
}
