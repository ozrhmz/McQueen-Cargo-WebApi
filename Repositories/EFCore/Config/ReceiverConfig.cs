using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class ReceiverConfig : IEntityTypeConfiguration<Receiver>
    {
        public void Configure(EntityTypeBuilder<Receiver> builder)
        {
            builder.HasOne(a => a.Country)
               .WithMany()
               .HasForeignKey(a => a.CountryId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Province)
                   .WithMany()
                   .HasForeignKey(a => a.ProvinceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.District)
                   .WithMany()
                   .HasForeignKey(a => a.DistrictId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Neighbourhood)
                   .WithMany()
                   .HasForeignKey(a => a.NeighbourhoodId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Receiver
            {
                Id = 1,
                NameSurname = "Mehmet Sakip",
                Email = "Test@gmail.com",
                NumberPhone = "0364106788",
                CountryId = 1,
                ProvinceId = 1,
                DistrictId = 1,
                NeighbourhoodId = 1,
                Street = "Garanti",
                BuildingNo = "42",
                ApartmentNumber = "9",
                Title = "Mehmet Ev",
                CustomerMobilId = 1,
                Floor = 1,
                Description = "Test Açıklama",
                IsInActive = false
            });
        }
    }
}
