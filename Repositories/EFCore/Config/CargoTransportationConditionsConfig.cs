using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CargoTransportationConditionsConfig : IEntityTypeConfiguration<CargoTransportationConditions>
    {
        public void Configure(EntityTypeBuilder<CargoTransportationConditions> builder)
        {
            builder.HasData(new CargoTransportationConditions
            {
                Id = 1,
                CargoTransportationConditionsName = "Kırılabilir",
                CargoTransportationConditionsPrice = 20
            },
            new CargoTransportationConditions
            {
                Id = 2,
                CargoTransportationConditionsName = "Dökülebilir",
                CargoTransportationConditionsPrice = 30
            },
            new CargoTransportationConditions
            {
                Id = 3,
                CargoTransportationConditionsName = "Normal",
                CargoTransportationConditionsPrice = 10
            });
        }
    }
}
