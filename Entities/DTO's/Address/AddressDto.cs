namespace Entities.DTO_s
{
    public record AddressDto
    {
        public int Id { get; init; }
        public int CountryId { get; init; }
        public string CountryName { get; init; }
        public int ProvinceId { get; init; }
        public string ProvinceName { get; init; }
        public int DistrictId { get; init; }
        public string DistrictName { get; init; }
        public int NeighbourhoodId { get; init; }
        public string NeighbourhoodName { get; init; }
        public string Street { get; init; }
        public string BuildingNo { get; init; }
        public string ApartmentNumber { get; init; }
        public int Floor { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string? CustomerNameSurname { get; set; }
    }
}
