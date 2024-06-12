using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class EmployeeTypeConfig : IEntityTypeConfiguration<EmployeesType>
    {
        public void Configure(EntityTypeBuilder<EmployeesType> builder)
        {
            builder.HasData(new EmployeesType
            {
                Id = 1,
                EmployeesTypeName = "Müdür"
            },
            new EmployeesType
            {
                Id = 2,
                EmployeesTypeName = "Kasiyer"
            },
            new EmployeesType
            {
                Id = 3,
                EmployeesTypeName = "Kurye"
            });
        }
    }
}
