using Microsoft.AspNetCore.Mvc;
using TaskFlowPro.API.Models;

namespace TaskFlowPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<User>> GetUsers()
    {
        var users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            }
        };

        return Ok(users);
    }
}