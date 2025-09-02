using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace R_EFcore.Data.Models
{
    /*poco class=>[plain pld clr object]

    we have 4 ways to map classes into table
    1-by convention [default behavior]
    2-data anotation

    [Table("Employees")]//you use Dbset so you can comment it*/
    internal class Employee
    {
        #region properties
        //[Key]//you use Id so you can comment it
        //public int Id { get; set; }//public numeric property named as "Id", "EmployeeId"="classnameId" => pk identity (1,1)

        public int EmpId { get; set; }

        // public string? Name { get; set; }//nvarchar(max)
        //nullable<string>

        [Required]
        [Column("EmployeeName", TypeName = "varchar")]
        [MaxLength(50, ErrorMessage = "Name of Employee must be less than 50 charcter")]//ErrorMessage: application validation will not be mapped in sql
        [MinLength(3, ErrorMessage = "name must be more than 3")]
        [StringLength(50, MinimumLength = 3)]
        public string name { get; set; }

        public double Salary { get; set; }//float

        [Required]
        [Range(25, 40)]
        //[AllowedValues(25, 26, 27)]
        //[DeniedValues(40, 39, 38)]
        public int Age { get; set; }


        //public int? age { get; set; }//nullable<int>

        [Phone]//Backend (Validation)
        [DataType(DataType.PhoneNumber)]//to display value as phone number ((Application Hint))
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [NotMapped]//not connected to sql
        public int test { get; set; }
        #endregion

        #region relationships
        //one to one ((employee may manage department and department must have a manager)) "manage"
        [InverseProperty(nameof(Department.manager))]
        public Department? managerDepartment { get; set; }//null: may have and may not 

        //one to many "work"

        //public int employeeDepartmentDeptId { get; set; } //fk = relationName + departmentId by convention
        [ForeignKey(nameof(employeeDepartment))]
        public int fkemployeeDepartmentDeptId { get; set; }
        [InverseProperty(nameof(Department.employees))]
        public Department employeeDepartment { get; set; } = null!;

        #endregion

    }
}

