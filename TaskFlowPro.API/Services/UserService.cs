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

    public async Task<List<User>> GetUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }
    public async Task<User?> UpdateUser(int id, User updatedUser)
    {
        var existingUser = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        if (existingUser == null)
        {
            return null;
        }

        existingUser.FirstName = updatedUser.FirstName;
        existingUser.LastName = updatedUser.LastName;
        existingUser.Email = updatedUser.Email;

        await _dbContext.SaveChangesAsync();

        return existingUser;
    }
    public async Task<bool> DeleteUser(int id)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return false;
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}