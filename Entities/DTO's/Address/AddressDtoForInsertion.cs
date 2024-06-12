namespace Entities.DTO_s
{
    public record AddressDtoForInsertion : AddressDtoForManipulation
    {
        public int CountryId { get; init; }
        public int ProvinceId { get; init; }
        public int DistrictId { get; init; }
        public int NeighbourhoodId { get; init; }
        public int CustomerMobilId { get; set; }
    }
}
