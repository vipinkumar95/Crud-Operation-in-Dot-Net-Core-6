using Microsoft.EntityFrameworkCore;

namespace CrudCore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Student> Studentes { get; set; }
    }
}
