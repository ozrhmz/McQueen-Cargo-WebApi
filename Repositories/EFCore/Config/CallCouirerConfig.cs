using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CallCouirerConfig : IEntityTypeConfiguration<CallCourier>
    {
        public void Configure(EntityTypeBuilder<CallCourier> builder)
        {
            builder.HasData(new CallCourier
            {
                Id = 1,
                CustomerMobilId = 1,
                CustomerMobilAdressId = 2,
                CargoTransportationConditionsId = 1,
                CargoTypeId = 1,
                PaymentTypeId = 1,
                CargoParcelTypeID = 1,
                ReceiverId = 1,
                CargoDesi = 1.24,
                CargoRealeseDate = DateTimeOffset.Now.UtcDateTime,
                Price = 40,
                CallCourierOk = false,
            });
        }
    }
}
