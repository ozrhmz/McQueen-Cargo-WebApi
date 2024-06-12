
namespace Entities.DTO_s.Address
{
    public record ProvinceDto
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public int CountryId { get; set; }
    }
}
