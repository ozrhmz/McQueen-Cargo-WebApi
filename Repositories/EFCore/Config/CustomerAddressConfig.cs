using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.EFCore.Config
{
    public class CustomerAddressConfig : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Customer)
                .WithMany(y => y.CustomerAddresses)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // ya da DeleteBehavior.SetNull

            builder.HasOne(x => x.Address)
                .WithMany(y => y.CustomerAddresses)
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Restrict); // ya da DeleteBehavior.SetNull

            builder.HasOne(x => x.CustomerMobil)
                .WithMany(y => y.CustomerAddresses)
                .HasForeignKey(x => x.CustomerMobilId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new CustomerAddress { Id = 1, CustomerId = 1, AddressId = 1 },
                new CustomerAddress { Id = 2, CustomerMobilId = 1, AddressId = 2 }
            );
        }
    }
}