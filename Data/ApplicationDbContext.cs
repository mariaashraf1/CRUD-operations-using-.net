using Microsoft.EntityFrameworkCore;
using studentPortal.web.Models.Entites;


namespace studentPortal.web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ):base(options)
        {
            
        }
        public DbSet<Student> students { get; set; }
    }
}
