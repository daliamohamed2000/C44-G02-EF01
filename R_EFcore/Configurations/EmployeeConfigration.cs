using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using R_EFcore.Data.Models;

namespace R_EFcore.Configurations
{
    internal class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> Ebuilder)
        {

            Ebuilder.Property(e => e.EmpId).UseIdentityColumn(1, 1);


            #region Relationships
            //relation one to one ((used without navigation property but cannot get data))
            //Ebuilder.HasOne<Department>().WithOne()
            //   .HasForeignKey<Department>(d=>d.DepartmentManagerId);

            Ebuilder.HasOne(e => e.managerDepartment).WithOne(d => d.manager)//with navigation property
                .HasForeignKey<Department>(d => d.DepartmentManagerId)
                .OnDelete(DeleteBehavior.NoAction);

            //one to many "work"
            Ebuilder.HasOne(e => e.employeeDepartment)
                .WithMany(d => d.employees)
                .HasForeignKey(e => e.fkemployeeDepartmentDeptId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion



        }
    }
}
