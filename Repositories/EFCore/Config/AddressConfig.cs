using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.EFCore.Config
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
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

            builder.HasData(new Address
            {
                Id = 1,
                CountryId = 1,
                ProvinceId = 1,
                DistrictId = 1,
                NeighbourhoodId = 1,
                Street = "Garanti Caddesi",
                BuildingNo = "40",
                Floor = 2,
                ApartmentNumber = "3",
                Title = "Ev",
                Description = "Test Açıklama"
            },
            new Address
            {
                Id = 2,
                CountryId = 1,
                ProvinceId = 1,
                DistrictId = 1,
                NeighbourhoodId = 1,
                Street = "Gazeteci Sokak",
                BuildingNo = "20",
                Floor = 5,
                ApartmentNumber = "10",
                Title = "Ev",
                Description = "Test Açıklama"
            });
        }
    }
}
