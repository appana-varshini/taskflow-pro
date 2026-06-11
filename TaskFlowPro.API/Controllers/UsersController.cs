using Microsoft.AspNetCore.Mvc;
using TaskFlowPro.API.Models;
using TaskFlowPro.API.Services;

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
    public ActionResult<List<User>> GetUsers()
    {
        var users = _userService.GetUsers();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        var createdUser = _userService.CreateUser(user);

        return Ok(createdUser);
    }

    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(int id, User user)
    {
        var updatedUser = _userService.UpdateUser(id, user);

        if (updatedUser == null)
        {
            return NotFound();
        }

        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var deleted = _userService.DeleteUser(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}