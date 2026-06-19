using TaskFlowPro.API.DTOs;
using TaskFlowPro.API.Models;

namespace TaskFlowPro.API.Services
{
    public interface IAuthService
    {
        Task<User?> Login(LoginDto loginDto);
    }
}