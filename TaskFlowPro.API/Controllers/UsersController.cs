using Microsoft.AspNetCore.Mvc;
using TaskFlowPro.API.Models;
using TaskFlowPro.API.Services;
using TaskFlowPro.API.DTOs;
using TaskFlowPro.API.Helpers;

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
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetUsers();

        return Ok(new ApiResponse<object>(
       true,
       "Users retrieved successfully.",
       users
        ));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new ApiResponse<object>(
        true,
        "User retrieved successfully.",
         user
        ));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
    {
        var user = new User
        {
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            Email = createUserDto.Email,
            Password = createUserDto.Password
        };

        var createdUser = await _userService.CreateUser(user);

        return CreatedAtAction(
         nameof(GetUserById),
         new { id = createdUser.Id },
         new ApiResponse<User>(
         true,
        "User created successfully.",
        createdUser
         )
         );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
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
            return NotFound(new ApiResponse<object>(
            false,
            "User not found.",
            null
            ));
        }

        return Ok(new ApiResponse<User>(
        true,
        "User updated successfully.",
        updatedUser
        ));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUser(id);

        if (!deleted)
        {
            return NotFound();
        }

        return Ok(new ApiResponse<object>(
          true,
        "User deleted successfully.",
        null
        ));
    }
}