namespace Entities.DTO_s.CargoStatus
{
    public record CargoParcelTypeDto
    {
        public int Id { get; init; }
        public string CargoParcelTypeName { get; init; }
        public string MaxSize { get; init; }
        public string DesiSize { get; init; }
        public double Price { get; init; }
        public string Information { get; init; }
    }
}
