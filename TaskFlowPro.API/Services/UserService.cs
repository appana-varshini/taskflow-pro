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

    public User? GetUserById(int id)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == id);
    }

    public User CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user;
    }
    public User? UpdateUser(int id, User updatedUser)
    {
        var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == id);

        if (existingUser == null)
        {
            return null;
        }

        existingUser.FirstName = updatedUser.FirstName;
        existingUser.LastName = updatedUser.LastName;
        existingUser.Email = updatedUser.Email;

        _dbContext.SaveChanges();

        return existingUser;
    }
    public bool DeleteUser(int id)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return false;
        }

        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();

        return true;
    }
}