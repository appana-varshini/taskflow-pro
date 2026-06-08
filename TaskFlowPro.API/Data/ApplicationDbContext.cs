using TaskFlowPro.API.Models;

namespace TaskFlowPro.API.Data
{
    public class ApplicationDbContext
    {
        public List<User> Users { get; set; } = new();

    }
}
