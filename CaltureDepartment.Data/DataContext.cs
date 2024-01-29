using CultureDepartment.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CultureDepartment.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=culure_department_db");
        }

    }
}
