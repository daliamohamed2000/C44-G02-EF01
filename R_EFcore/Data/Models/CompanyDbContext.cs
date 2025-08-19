using Microsoft.EntityFrameworkCore;

namespace R_EFcore.Data.Models
{
    internal class CompanyDbContext : DbContext
    {
        //CompanyDbContext() : base()
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AR988PM;Database=CompanyG04;Trusted_Connection=true;trustservercertificate=true");
        }
        public DbSet<Employee> Employees { get; set; }
        //class called Employee, table in sql called Employees
    }
}
