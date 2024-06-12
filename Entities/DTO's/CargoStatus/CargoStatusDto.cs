namespace Entities.DTO_s.CargoStatus
{
    public record CargoStatusDto
    {
        public int Id { get; init; }
        public string ShippingStatusName { get; init; }
        public string Information { get; set; }
    }
}
