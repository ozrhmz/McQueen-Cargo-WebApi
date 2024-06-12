using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CustomerMobilConfig : IEntityTypeConfiguration<CustomerMobil>
    {
        public void Configure(EntityTypeBuilder<CustomerMobil> builder)
        {
            builder.HasData(new CustomerMobil
            {
                Id = 1,
                Name = "Hamza",
                Surname = "Özer",
                TcNo = "10000000000",
                NumberPhone = "05417434515",
                Password = "asdasd123a",
                BirthDate = DateTime.Now,
                Email = "test@gmail.com"
            },
            new CustomerMobil
            {
                Id = 2,
                Name = "Murat",
                Surname = "Çalış",
                TcNo = "11000000000",
                NumberPhone = "05415414141",
                Password = "asdasd123asd",
                BirthDate = DateTime.Now,
                Email = "test2@gmail.com"
            });
        }
    }
}
