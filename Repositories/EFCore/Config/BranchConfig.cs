using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repositories.EFCore.Config
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasData(
                new Branch { Id = 1, BranchName = "Adalar", DistrictId = 1 },
                new Branch { Id = 2, BranchName = "Arnavutköy", DistrictId = 2 },
                new Branch { Id = 3, BranchName = "Ataşehir", DistrictId = 3 },
                new Branch { Id = 4, BranchName = "Avcılar", DistrictId = 4 },
                new Branch { Id = 5, BranchName = "Bağcılar", DistrictId = 5 },
                new Branch { Id = 6, BranchName = "Bahçelievler", DistrictId = 6 },
                new Branch { Id = 7, BranchName = "Bakırköy", DistrictId = 7 },
                new Branch { Id = 8, BranchName = "Başakşehir", DistrictId = 8 },
                new Branch { Id = 9, BranchName = "Bayrampaşa", DistrictId = 9 },
                new Branch { Id = 10, BranchName = "Beşiktaş", DistrictId = 10 },
                new Branch { Id = 11, BranchName = "Beykoz", DistrictId = 11 },
                new Branch { Id = 12, BranchName = "Beylikdüzü", DistrictId = 12 },
                new Branch { Id = 13, BranchName = "Beyoğlu", DistrictId = 13 },
                new Branch { Id = 14, BranchName = "Büyükçekmece", DistrictId = 14 },
                new Branch { Id = 15, BranchName = "Çatalca", DistrictId = 15 },
                new Branch { Id = 16, BranchName = "Çekmeköy", DistrictId = 16 },
                new Branch { Id = 17, BranchName = "Esenler", DistrictId = 17 },
                new Branch { Id = 18, BranchName = "Esenyurt", DistrictId = 18 },
                new Branch { Id = 19, BranchName = "Eyüpsultan", DistrictId = 19 },
                new Branch { Id = 20, BranchName = "Fatih", DistrictId = 20 },
                new Branch { Id = 21, BranchName = "Gaziosmanpaşa", DistrictId = 21 },
                new Branch { Id = 22, BranchName = "Güngören", DistrictId = 22 },
                new Branch { Id = 23, BranchName = "Kadıköy", DistrictId = 23 },
                new Branch { Id = 24, BranchName = "Kağıthane", DistrictId = 24 },
                new Branch { Id = 25, BranchName = "Kartal", DistrictId = 25 },
                new Branch { Id = 26, BranchName = "Küçükçekmece", DistrictId = 26 },
                new Branch { Id = 27, BranchName = "Maltepe", DistrictId = 27 },
                new Branch { Id = 28, BranchName = "Pendik", DistrictId = 28 },
                new Branch { Id = 29, BranchName = "Sancaktepe", DistrictId = 29 },
                new Branch { Id = 30, BranchName = "Sarıyer", DistrictId = 30 },
                new Branch { Id = 31, BranchName = "Silivri", DistrictId = 31 },
                new Branch { Id = 32, BranchName = "Sultanbeyli", DistrictId = 32 },
                new Branch { Id = 33, BranchName = "Sultangazi", DistrictId = 33 },
                new Branch { Id = 34, BranchName = "Şile", DistrictId = 34 },
                new Branch { Id = 35, BranchName = "Şişli", DistrictId = 35 },
                new Branch { Id = 36, BranchName = "Tuzla", DistrictId = 36 },
                new Branch { Id = 37, BranchName = "Ümraniye", DistrictId = 37 },
                new Branch { Id = 38, BranchName = "Üsküdar", DistrictId = 38 },
                new Branch { Id = 39, BranchName = "Zeytinburnu", DistrictId = 39 });
        }
    }
}
