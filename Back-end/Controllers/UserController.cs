using Microsoft.AspNetCore.Mvc;
using TwitterClone.Models;
using TwitterClone.Services;

namespace TwitterClone.Controllers;

[ApiController]
[Route("user/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        this._userService = userService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(_userService.GetAll());
    }
    
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<User>> GetUserById(int id)
    {
        return Ok(_userService.GetUserWithTweets(id));
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] User user)
    {
        var createdUser = await _userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }
}