using Microsoft.AspNetCore.Mvc;
using TaskFlowPro.API.Models;
using TaskFlowPro.API.Services;
using TaskFlowPro.API.DTOs;

namespace TaskFlowPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var users = await _userService.GetUsers();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(CreateUserDto createUserDto)
    {
        var user = new User
        {
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            Email = createUserDto.Email
        };

        var createdUser = await _userService.CreateUser(user);

        return Ok(createdUser);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var user = new User
        {
            FirstName = updateUserDto.FirstName,
            LastName = updateUserDto.LastName,
            Email = updateUserDto.Email
        };

        var updatedUser = await _userService.UpdateUser(id, user);

        if (updatedUser == null)
        {
            return NotFound();
        }

        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUser(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}