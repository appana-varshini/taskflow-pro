using Microsoft.AspNetCore.Mvc;
using TaskFlowPro.API.Models;
using TaskFlowPro.API.Services;

namespace TaskFlowPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
   
    private readonly UserService _userService = new();

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

        return Ok(user);
    }
}