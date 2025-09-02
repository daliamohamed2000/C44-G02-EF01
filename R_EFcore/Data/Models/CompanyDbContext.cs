using System.Reflection;
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
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }

        //FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.EmpId);

            modelBuilder.Entity<Employee>().Property(e => e.EmpId).UseIdentityColumn(1, 1);
            //.UseIdentityColumn(1, 2);//1,3,5,7,..
            //modelBuilder.Entity<Employee>().Property("EmpId");
            //modelBuilder.Entity<Employee>().Property(nameof(Employee.EmpId));

            //modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfigration());//use this for employee
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigrations());//use this for department
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//use this for all
        }

    }
}
/*
 * public numeric property named as "Id", "EmployeeId"="classnameId" => pk identity (1,1) ((by convention))
 * if pk="empid"=> you should mention it to be [Key] ((data anotation)) but not has an identity
 * 
 * you can make a table of Employee by 2 ways:
 * 1-use Dbset
 * 2-[Table("Employees")] ((data anotation))
 * 
 * [NotMapped]
 * public string FullName => FirstName + " " + LastName;
 * it is a varible gets value from ther variables
 * 
 * 3-FluentAPI
 * 
 */