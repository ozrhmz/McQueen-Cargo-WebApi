using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CargoTypeConfig : IEntityTypeConfiguration<CargoType>
    {
        public void Configure(EntityTypeBuilder<CargoType> builder)
        {
            builder.HasData(new CargoType
            {
                Id = 1,
                CargoTypeName = "Normal Teslimat",
                CargoTypePrice = 15
            },
            new CargoType
            {
                Id = 2,
                CargoTypeName = "Aynı Gün Teslimat",
                CargoTypePrice = 30
            });
        }
    }
}
