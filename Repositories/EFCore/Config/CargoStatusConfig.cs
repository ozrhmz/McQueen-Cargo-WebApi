using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.EFCore.Config
{
    public class CargoStatusConfig : IEntityTypeConfiguration<CargoStatus>
    {
        public void Configure(EntityTypeBuilder<CargoStatus> builder)
        {
            builder.HasData(new CargoStatus
            {
                Id = 1,
                ShippingStatusName = "Kargoya Verildi",
                Information = "Kargonuz çıkış şubesinden transfer merkezine gönderilmek üzere aracımıza yüklenmiştir."
            },
            new CargoStatus
            {
                Id = 2,
                ShippingStatusName = "Yolda",
                Information = "Kargonuz çıkış transfer merkezinden varış transfer merkezine gönderiliyor."
            },
            new CargoStatus
            {
                Id = 3,
                ShippingStatusName = "Yolda",
                Information = "Kargonuz varış transfer merkezine indirilmiştir."
            },
            new CargoStatus
            {
                Id = 4,
                ShippingStatusName = "Yolda",
                Information = "Kargonuz varış transfer merkezinden varış şubesine gönderiliyor."
            },
            new CargoStatus
            {
                Id = 5,
                ShippingStatusName = "Teslimat Şubesinde",
                Information = "Kargonuz transfer merkezimizden teslimat şubemize ulaşmıştır"

            },
            new CargoStatus
            {
                Id = 6,
                ShippingStatusName = "Teslimatta",
                Information = "Kargonuz teslim edilmek üzere kuryeye zimmetlenmiştir."
            },
            new CargoStatus
            {
                Id = 7,
                ShippingStatusName = "Teslim Edildi",
                Information = "Kargo alıcıya teslim edildi."
            },
            new CargoStatus
            {
                Id = 8,
                ShippingStatusName = "Teslim Edilemedi",
                Information = "Geldik yoktunuz CcC."
            });
        }
    }
}
