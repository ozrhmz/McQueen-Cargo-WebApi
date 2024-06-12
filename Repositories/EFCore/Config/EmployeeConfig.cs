using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {

            builder.HasOne(x => x.Branch)
                .WithMany()
                .HasForeignKey(x => x.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Employees
            {
                Id = 1,
                Name = "Name",
                Surname = "Surname",
                TcNo = "99999999999",
                NumberPhone = "05417434511",
                Password = "Password",
                EmployeesTypeId = 1,
                BranchId = 14,
            },
            new Employees
            {
                Id = 2,
                Name = "Surname",
                Surname = "Name",
                TcNo = "99999999998",
                NumberPhone = "05417434510",
                Password = "Password1",
                EmployeesTypeId = 2,
                BranchId = 19,
            });
        }
    }
}
