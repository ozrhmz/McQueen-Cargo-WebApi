using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class DistrictConfig : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasData(
                new District { Id = 1, DistrictName = "Adalar", ProvinceId = 1 },
                new District { Id = 2, DistrictName = "Arnavutköy", ProvinceId = 1 },
                new District { Id = 3, DistrictName = "Ataşehir", ProvinceId = 1 },
                new District { Id = 4, DistrictName = "Avcılar", ProvinceId = 1 },
                new District { Id = 5, DistrictName = "Bağcılar", ProvinceId = 1 },
                new District { Id = 6, DistrictName = "Bahçelievler", ProvinceId = 1 },
                new District { Id = 7, DistrictName = "Bakırköy", ProvinceId = 1 },
                new District { Id = 8, DistrictName = "Başakşehir", ProvinceId = 1 },
                new District { Id = 9, DistrictName = "Bayrampaşa", ProvinceId = 1 },
                new District { Id = 10, DistrictName = "Beşiktaş", ProvinceId = 1 },
                new District { Id = 11, DistrictName = "Beykoz", ProvinceId = 1 },
                new District { Id = 12, DistrictName = "Beylikdüzü", ProvinceId = 1 },
                new District { Id = 13, DistrictName = "Beyoğlu", ProvinceId = 1 },
                new District { Id = 14, DistrictName = "Büyükçekmece", ProvinceId = 1 },
                new District { Id = 15, DistrictName = "Çatalca", ProvinceId = 1 },
                new District { Id = 16, DistrictName = "Çekmeköy", ProvinceId = 1 },
                new District { Id = 17, DistrictName = "Esenler", ProvinceId = 1 },
                new District { Id = 18, DistrictName = "Esenyurt", ProvinceId = 1 },
                new District { Id = 19, DistrictName = "Eyüpsultan", ProvinceId = 1 },
                new District { Id = 20, DistrictName = "Fatih", ProvinceId = 1 },
                new District { Id = 21, DistrictName = "Gaziosmanpaşa", ProvinceId = 1 },
                new District { Id = 22, DistrictName = "Güngören", ProvinceId = 1 },
                new District { Id = 23, DistrictName = "Kadıköy", ProvinceId = 1 },
                new District { Id = 24, DistrictName = "Kağıthane", ProvinceId = 1 },
                new District { Id = 25, DistrictName = "Kartal", ProvinceId = 1 },
                new District { Id = 26, DistrictName = "Küçükçekmece", ProvinceId = 1 },
                new District { Id = 27, DistrictName = "Maltepe", ProvinceId = 1 },
                new District { Id = 28, DistrictName = "Pendik", ProvinceId = 1 },
                new District { Id = 29, DistrictName = "Sancaktepe", ProvinceId = 1 },
                new District { Id = 30, DistrictName = "Sarıyer", ProvinceId = 1 },
                new District { Id = 31, DistrictName = "Silivri", ProvinceId = 1 },
                new District { Id = 32, DistrictName = "Sultanbeyli", ProvinceId = 1 },
                new District { Id = 33, DistrictName = "Sultangazi", ProvinceId = 1 },
                new District { Id = 34, DistrictName = "Şile", ProvinceId = 1 },
                new District { Id = 35, DistrictName = "Şişli", ProvinceId = 1 },
                new District { Id = 36, DistrictName = "Tuzla", ProvinceId = 1 },
                new District { Id = 37, DistrictName = "Ümraniye", ProvinceId = 1 },
                new District { Id = 38, DistrictName = "Üsküdar", ProvinceId = 1 },
                new District { Id = 39, DistrictName = "Zeytinburnu", ProvinceId = 1 });


        }
    }
}
