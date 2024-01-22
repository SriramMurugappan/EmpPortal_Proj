using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Domain;

namespace WebApplication2.Data
{
    public class MvcDBContext : DbContext
    {
        public MvcDBContext() { }
        public MvcDBContext(DbContextOptions<MvcDBContext> options) : base(options) //options parameter allows to provide config settings
        {
        }

        //properties are used to access the table that ef core will create in the database
        public DbSet<Employee> Employees { get; set; } //Employees will be the table created inside ssms
    }
}
