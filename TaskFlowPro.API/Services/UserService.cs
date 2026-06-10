using TaskFlowPro.API.Models;
using TaskFlowPro.API.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskFlowPro.API.Services;

public class UserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<User> GetUsers()
    {
        return _dbContext.Users.ToList();
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

    public User CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user;
    }
}