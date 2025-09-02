using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace R_EFcore.Configurations
{
    internal class DepartmentConfigrations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //modelBuilder.Entity<Department>().ToTable("Departments", "sales"); //nameOfTable, nameOfSchema 

            builder.HasKey(d => d.DeptId);

            builder.Property(d => d.DeptId)
            //.ValueGeneratedNever();//disableIdentityConstraint
                .UseIdentityColumn(1, 1);

            builder.Property(d => d.DeptName)
            .HasColumnName("department name").HasColumnType("varchar")
            .HasMaxLength(50).IsRequired(false);

            builder.Property(d => d.dateOfCreation)
                  //.HasDefaultValue(DateTime.Now); //get the date of migration creation (fixed time)
                  .HasDefaultValueSql("GETDATE()"); //sql get date at each time of insert
                                                    //.HasComputedColumnSql("GETDATE()");  //sql get date at each time of select

            //one to one relation
            //builder.HasOne<Employee>().WithOne()
            //    .HasForeignKey<Department>(d => d.DepartmentManagerId);
        }
    }
}
