using R_EFcore.Data.Models;
using R_EFcore.Data_Seeding;

namespace R_EFcore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Session 01
            //using CompanyDbContext dbContext = new CompanyDbContext();
            //var employee = dbContext.Employees.Where(e => e.age > 20);


            //dbContext.Database.Migrate();
            //CompanyDbContext dbContext = new CompanyDbContext();
            //try
            //{

            //}
            //finally
            //{
            //    dbContext.Dispose();
            //}
            #endregion
            #region Session 02
            /*----------------------------------------Connection--------------------------------------------*/

            //CompanyDbContext dbContext = new CompanyDbContext();
            //try
            //{
            //    //crud => query object model
            //}
            //finally
            //{
            //    //realse || free || deallocate || close || dispose unmanged resources
            //    dbContext.Dispose();
            //}

            using CompanyDbContext dbContext = new CompanyDbContext();

            /*---------------------------------------Crud Operations-------------------------------------------*/

            //~~ 1-insert ((detached)) ~~//

            Employee employee01 = new Employee()
            {
                //EmpId = 1, //invalid => column has identity
                name = "dalia",
                Age = 21,
                Salary = 20000,
                EmailAddress = "dm1956@gmil.com",
                PhoneNumber = "012193248234"
            };
            Employee employee02 = new Employee()
            {
                name = "rana",
                Age = 24,
                Salary = 25000,
                EmailAddress = "rh@gmil.com",
                PhoneNumber = "011283746353"
            };
            //Console.WriteLine(dbContext.Entry(employee01).State);//detached

            //~~ 2-Adding((added)) ~~//
            //added locally

            //dbContext.Employees.Add(employee01);
            //dbContext.Employees.Add(employee02);

            ////dbContext.Set<Employee>().Add(employee01);
            ////dbContext.Add(employee01);
            ////dbContext.Entry(employee01).State = EntityState.Added;
            //Console.WriteLine(dbContext.Entry(employee01).State);//added
            //Console.WriteLine(dbContext.Entry(employee02).State);//added

            //~~ 3-add in database((unchanged)) ~~//
            //added remotely

            //dbContext.SaveChanges();
            //Console.WriteLine(dbContext.Entry(employee01).State);//unchanged
            //Console.WriteLine(dbContext.Entry(employee02).State);//unchanged

            //Console.WriteLine(employee01.EmpId);
            //Console.WriteLine(employee02.EmpId);

            //~~ 4-read/retrive ~~//

            //var employeeID3 = (from e in dbContext.Employees
            //                 where e.EmpId == 3
            //                 select e).FirstOrDefault();
            //Console.WriteLine(employeeID3?.name ?? "not found");

            //~~ 5-update ~~// ((modified))

            //var employeeID1 = (from e in dbContext.Employees
            //                   where e.EmpId == 1
            //                   select e).FirstOrDefault();
            //Console.WriteLine(dbContext.Entry(employeeID1).State);//unchanged
            //employeeID1.name = "heba"; //updata local
            //Console.WriteLine(dbContext.Entry(employeeID1).State);//modified
            //dbContext.SaveChanges();  // update remote
            //Console.WriteLine(dbContext.Entry(employeeID1).State);//unchanged

            //~~ 6-removed ~~//
            //var employeeID1 = (from e in dbContext.Employees
            //                   where e.EmpId == 1
            //                   select e).FirstOrDefault();
            //Console.WriteLine(dbContext.Entry(employeeID1).State);//unchanged
            //dbContext.Employees.Remove(employeeID1);
            //Console.WriteLine(dbContext.Entry(employeeID1).State);//deleted
            //dbContext.SaveChanges();  // update remote
            //Console.WriteLine(dbContext.Entry(employeeID1).State);//detached
            #endregion

            using CompanyDbContext dbcontext = new CompanyDbContext();
            CompanySeeding.DataSeeding(dbcontext);

            #region load navigational property 
            //var employeeWithDepartment = dbcontext.Employees.FirstOrDefault(e => e.EmpId == 7);
            ////request to database
            //if (employeeWithDepartment is not null)
            //{
            //    Console.WriteLine(employeeWithDepartment.name);
            //    Console.WriteLine(employeeWithDepartment.fkemployeeDepartmentDeptId);
            //    Console.WriteLine(employeeWithDepartment.employeeDepartment?.DeptName);
            //}
            #endregion

            #region loading related data
            #region egar loading
            //var employeeWithDepartment = dbcontext.Employees.Include(e => e.employeeDepartment).FirstOrDefault(e => e.EmpId == 7);
            ////request to database
            //if (employeeWithDepartment is not null)
            //{
            //    Console.WriteLine(employeeWithDepartment.name);
            //    Console.WriteLine(employeeWithDepartment.fkemployeeDepartmentDeptId);
            //    Console.WriteLine(employeeWithDepartment.employeeDepartment?.DeptName);
            //}

            //var employeeWithDepartment = dbcontext.Employees.Include(e => e.employeeDepartment)
            //    .ThenInclude(d => d.manager).FirstOrDefault(e => e.EmpId == 7);
            //if (employeeWithDepartment is not null)
            //{
            //    Console.WriteLine(employeeWithDepartment.name);
            //    Console.WriteLine(employeeWithDepartment.fkemployeeDepartmentDeptId);
            //    Console.WriteLine(employeeWithDepartment.employeeDepartment?.DeptName);
            //    Console.WriteLine(employeeWithDepartment.employeeDepartment?.manager?.EmpId);
            //    Console.WriteLine(employeeWithDepartment.employeeDepartment?.manager?.name);
            //}

            //var employeeWithDepartment = dbcontext.Employees.Include(e => e.employeeDepartment)
            //    .Where(e => e.employeeDepartment.DeptName == "sales")
            //    .Select(e => new
            //    {
            //        EmployeeName = e.name,
            //        DepartmentName = e.employeeDepartment.DeptName
            //    });
            //if (employeeWithDepartment.Any())
            //{
            //    foreach( var employee in employeeWithDepartment )
            //    {
            //        Console.WriteLine(employee);
            //    }
            //}
            #endregion
            #region explicit loading

            //var employeeWithDepartment = dbcontext.Employees.FirstOrDefault(e => e.EmpId == 1);
            ////request to database
            //dbcontext.Entry(employeeWithDepartment).Reference(e=>e.employeeDepartment).Load();
            //if (employeeWithDepartment is not null)
            //{
            //    Console.WriteLine(employeeWithDepartment.name);
            //    Console.WriteLine(employeeWithDepartment.fkemployeeDepartmentDeptId);
            //    Console.WriteLine(employeeWithDepartment?.name);
            //}

            //var departmentWithEmployess = dbcontext.Departments.FirstOrDefault(d => d.DeptId == 1);
            //if (departmentWithEmployess is not null)
            //{
            //    Console.WriteLine(departmentWithEmployess.DeptName);
            //    dbcontext.Entry(departmentWithEmployess).Collection(d => d.employees).Load();
            //    foreach (var emp in departmentWithEmployess.employees)
            //    {
            //        Console.WriteLine(emp.name);
            //    }
            //}
            #endregion
            #endregion
            #region Join [join()]
            #region Department That Has Employee
            //var Result = _dbContext.Departments.Join
            //    (_dbContext.Employees,
            //    D => D.DeptId,
            //    E => E.DepartmentDeptId,
            //    (D, E) => new
            //    {
            //        EmployeeId = E.Id,
            //        EmployeeName = E.Name,
            //        DepartmentId = D.DeptId,
            //        DepartmentName = D.DeptName,
            //    });
            //  var Result = from D in _dbContext.Departments
            //               join E in _dbContext.Employees
            //               on D.DeptId equals E.DepartmentDeptId
            //               select new
            //               {
            //                   EmployeeId = E.Id,
            //                   EmployeeName = E.Name,
            //                   DepartmentId = D.DeptId,
            //                   DepartmentName = D.DeptName,
            //               };
            //foreach(var item in Result)
            //  {
            //      Console.WriteLine(item);
            //  }
            #endregion
            #endregion
            #region Group Join
            #region Example 01
            //var Result = _dbContext.Departments.GroupJoin
            //   (_dbContext.Employees,
            //   D => D.DeptId,
            //   E => E.DepartmentDeptId,
            //  (D, Employees) => new
            //  {
            //      Department = D,
            //      Employees

            //  });
            //  foreach(var item in Result)
            //{
            //    Console.WriteLine($"DepartmentId:= {item.Department.DeptId}--DepartmentName:{item.Department.DeptName}");
            //    foreach( var emp in item.Employees)
            //    {
            //        Console.WriteLine($"================={emp.Name}");
            //    }
            //}
            #endregion
            #endregion
            #region Cross Join
            //var Result = from E in _dbContext.Employees
            //             from D in _dbContext.Departments
            //             select new
            //             {
            //                 E.Name,
            //                 D.DeptName
            //             };
            // foreach(var item in Result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
        }
    }
}

/*
 * to add migration: Add-Migration "migration_name"
 * to apply migration: update-database
 * to remove migration: Remove-Migration [must not be applied]
 * to rollback migration: update-database -Migration "previous_migration"
 * to rollback first migration: update-database 0
 * ------------------------------------------------------------------------------
 * Entry States:
 * ==============
 * Detached: The object is not being tracked by the database context.
 * Unchanged: The object exists in the database and has not been modified.
 * Deleted: The object exists in the database but is marked for deletion.
 * Modified: The object exists in the database and has been updated.
 * Added: The object does not exist in the database but is marked to be inserted.
 * 
 */ 