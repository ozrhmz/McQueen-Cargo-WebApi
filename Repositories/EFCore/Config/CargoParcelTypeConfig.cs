using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CargoParcelTypeConfig : IEntityTypeConfiguration<CargoParcelType>
    {
        public void Configure(EntityTypeBuilder<CargoParcelType> builder)
        {
            builder.HasData(new CargoParcelType
            {
                Id = 1,
                CargoParcelTypeName = "Small",
                MaxSize = "31",
                DesiSize = "6.0 - 10.0 kg",
                Price = 10,
                Information = "Bu pakete ortalama boydaki bir dergiden 15 adet yerleştirebilirisiniz.Kitaplarınız,orta boy bir hediye kutusu veya" +
                "2 top fotokopi kağıdı sığabilir."
            },
            new CargoParcelType
            {
                Id = 2,
                CargoParcelTypeName = "Medium",
                MaxSize = "36",
                DesiSize = "11.0 - 15.0 kg",
                Price = 20,
                Information = "Bu pakete ortalama boydaki bir dergiden 25 adet yerleştirebilirisiniz.Kitaplarınız,orta boy bir hediye kutusu veya" +
                "3 top fotokopi kağıdı sığabilir."
            },
            new CargoParcelType
            {
                Id = 3,
                CargoParcelTypeName = "Large",
                MaxSize = "41",
                DesiSize = "16.0 - 20.0 kg",
                Price = 30,
                Information = "Bu pakete ortalama boydaki bir dergiden 25 adet yerleştirebilirisiniz.Kitaplarınız,orta boy bir hediye kutusu veya" +
                "4 top fotokopi kağıdı sığabilir."
            },
            new CargoParcelType
            {
                Id = 4,
                CargoParcelTypeName = "X-Large",
                MaxSize = "46",
                DesiSize = "21.0 - 25.0 kg",
                Price = 40,
                Information = "Ortalama koli boyutu 30Cm x 22cm x 22cm"
            },
            new CargoParcelType
            {
                Id = 5,
                CargoParcelTypeName = "Dosya - Evrak",
                MaxSize = "5",
                DesiSize = "5 Kg",
                Price = 20,
                Information = ""
            }, new CargoParcelType
            {
                Id = 6,
                CargoParcelTypeName = "Koli",
                MaxSize = "45",
                DesiSize = "21.0 - 25.0 kg",
                Price = 40,
                Information = "Ortalama koli boyutu 30Cm x 22cm x 22cm"
            });
        }
    }
}
