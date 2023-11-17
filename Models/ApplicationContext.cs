using Microsoft.EntityFrameworkCore;

namespace LR12.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<UserModel> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
