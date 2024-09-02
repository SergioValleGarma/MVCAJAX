using Microsoft.EntityFrameworkCore;

namespace MVCAJAX.Models
{
    public class ExamenContext : DbContext
    {
        public DbSet<Productos> Productos { get; set; }

        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options) 
        { 
        }
    }
}
