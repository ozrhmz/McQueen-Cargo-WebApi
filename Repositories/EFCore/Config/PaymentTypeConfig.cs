using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class PaymentTypeConfig : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasData(new PaymentType
            {
                Id = 1,
                PaymentTypeName = "Alıcı Ödemeli"
            },
            new PaymentType
            {
                Id = 2,
                PaymentTypeName = "Gönderici Ödemeli"
            });
        }
    }
}
