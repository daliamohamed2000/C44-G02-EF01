using System.ComponentModel.DataAnnotations.Schema;
using R_EFcore.Data.Models;

namespace R_EFcore
{
    internal class Department
    {
        #region properties
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public DateOnly? dateOfCreation { get; set; }
        #endregion

        #region relationships
        //one to one ((employee may manage department and department must have a manager))
        public Employee? manager { get; set; } = null!;//NavigationProperty

        [ForeignKey(nameof(manager))] //data anotation 
        public int? DepartmentManagerId { get; set; }
        //EFcore will understand foreign key if: by convension
        /* NavigationPropertyName + Id
         * NavigationPropertyName + <PrincipalKeyName>
         * ClassName + Id
         * ClassName + <PrincipalKeyName>*/

        //one to many "work"
        [InverseProperty(nameof(Employee.employeeDepartment))]
        public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();

        #endregion



    }
}
