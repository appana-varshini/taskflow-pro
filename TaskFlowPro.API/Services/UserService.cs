using TaskFlowPro.API.Models;
using TaskFlowPro.API.Data;

namespace TaskFlowPro.API.Services;

public class UserService
{
    private readonly ApplicationDbContext _dbContext = new();
    public List<User> GetUsers()
    {
        if (!_dbContext.Users.Any())
        {
            _dbContext.Users.Add(
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com"
                });
        }

        return _dbContext.Users;
    }

    public User GetUserById(int id)
    {
        return new User
        {
            Id = id,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };
    }
}