using Microsoft.EntityFrameworkCore;

namespace LR12.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<CompanyModel> Companies { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
