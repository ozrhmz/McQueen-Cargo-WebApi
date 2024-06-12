using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CargoMovementConfig : IEntityTypeConfiguration<CargoMovement>
    {
        public void Configure(EntityTypeBuilder<CargoMovement> builder)
        {


            builder.HasData(new CargoMovement
            {
                Id = 1,
                BranchId = 1,
                CallCourierId = 1,
                CargoStatusId = 7,
                Date = DateTime.Now
            });
        }
    }
}
