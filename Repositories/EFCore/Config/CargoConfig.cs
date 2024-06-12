using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CargoConfig : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {

            builder.HasOne(c => c.CargoDepartureBranch)
                .WithMany()
                .HasForeignKey(c => c.CargoDepartureBranchId)
                .OnDelete(DeleteBehavior.Restrict); // Silme işlemi NO ACTION olarak belirlendi

            builder.HasOne(c => c.CargoArrivalBranch)
                .WithMany()
                .HasForeignKey(c => c.CargoArrivalBranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Cargo
            {
                Id = 1,
                CustomerMobilId = 1,
                CustomerMobilAdressId = 1,
                CargoDepartureBranchId = 1,
                CargoArrivalBranchId = 2,
                ReceiverId = 1,
                CargoParcelTypeId = 1,
                PaymentTypeId = 1,
                CargoTransportationConditionsId = 1,
                CargoTypeId = 1,
                CargoDesi = 19,
                CargoReleaseDate = DateTime.Now,
                CargoDeliveryDate = DateTime.Now.AddDays(3),
                CargoEstimatedDeliveryDate = DateTime.Now.AddDays(5),
                Price = 122,
                CargoTrackingNo = "KT10100100",
                CargoStatusId = 1
            });
        }
    }
}
