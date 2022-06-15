using Microsoft.EntityFrameworkCore;
using MockTask.Models;

namespace MockTask.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)   
        {

        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Classes> Classes { get; set; }
    }
}
