using Microsoft.EntityFrameworkCore;
using WebApplication_Server.Models;

namespace WebApplication_Server.Repositories
{
    public class PatientContext : DbContext
    {

        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=ServerDb;Integrated Security=True;");
        }
    }
}
