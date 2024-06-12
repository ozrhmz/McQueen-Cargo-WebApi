using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { Id = 1, Name = "Hamza", Surname = "Özer", TCNo = "00000000000", NumberPhone = "01234567890", CreatedDate = "2.09.2023", BirthDate = DateTime.Now, Email = "test@gmail.com" },
                new Customer { Id = 2, Name = "Murat", Surname = "Çalış", TCNo = "00000000001", NumberPhone = "01234567891", CreatedDate = "2.09.2023", BirthDate = DateTime.Now, Email = "test2@gmail.com" },
                new Customer { Id = 3, Name = "Ömer", Surname = "Küçükahıskalı", TCNo = "00000000002", NumberPhone = "01234567892", CreatedDate = "2.09.2023", BirthDate = DateTime.Now, Email = "test3@gmail.com" }
            );
        }
    }
}
