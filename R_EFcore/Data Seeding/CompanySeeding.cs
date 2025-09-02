using System.Text.Json;
using R_EFcore.Data.Models;

namespace R_EFcore.Data_Seeding
{
    internal static class CompanySeeding
    {
        public static bool DataSeeding(CompanyDbContext dbContext)
        {
            try
            {
                #region department
                if (!dbContext.Departments.Any())
                {
                    var departmentData = File.ReadAllText("F:\\Users\\mr\\source\\repos\\R_EFcore\\R_EFcore\\bin\\Debug\\net9.0\\Files\\departments.json");
                    var departments = JsonSerializer.Deserialize<List<Department>>(departmentData);
                    if (departments?.Count > 0)
                    {
                        dbContext.AddRange(departments);//local
                        dbContext.SaveChanges();//to database
                    }
                }
                #endregion
                #region employee
                if (!dbContext.Employees.Any())
                {
                    var employeeData = File.ReadAllText("F:\\Users\\mr\\source\\repos\\R_EFcore\\R_EFcore\\bin\\Debug\\net9.0\\Files\\employees.json");
                    var employees = JsonSerializer.Deserialize<List<Employee>>(employeeData);
                    if (employees?.Count > 0)
                    {
                        dbContext.AddRange(employees);//local
                        dbContext.SaveChanges();//to database
                    }
                }
                #endregion
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
