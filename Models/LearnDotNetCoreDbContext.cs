using Microsoft.EntityFrameworkCore;

namespace LearnDotNetCore.Models
{
    public class LearnDotNetCoreDbContext : DbContext
    {
        public LearnDotNetCoreDbContext(DbContextOptions<LearnDotNetCoreDbContext> options): base(options)
        {

        }
        public  DbSet<Employee>  Employees { get; set; }
    }
}
