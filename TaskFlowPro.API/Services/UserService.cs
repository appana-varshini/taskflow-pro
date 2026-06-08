using TaskFlowPro.API.Models;

namespace TaskFlowPro.API.Services;

public class UserService
{
    public List<User> GetUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com"
            }
        };
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