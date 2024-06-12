
namespace Entities.DTO_s.Address
{
    public record DistrictDto
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int ProvinceId { get; set; }
    }
}
