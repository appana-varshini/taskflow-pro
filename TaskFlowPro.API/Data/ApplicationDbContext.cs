using Microsoft.EntityFrameworkCore;
using TaskFlowPro.API.Models;

namespace TaskFlowPro.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}