using _4FinanceTMS.Models;
using Microsoft.EntityFrameworkCore;

namespace _4FinanceTMS.Data
{
    public class TMSDbContext : DbContext
    { //ctor
        public TMSDbContext(DbContextOptions <TMSDbContext> options ) : base( options )
        {

        }
        //if table does not exit, create it
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
   
}
