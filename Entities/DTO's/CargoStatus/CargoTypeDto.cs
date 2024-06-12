namespace Entities.DTO_s.CargoStatus
{
    public record CargoTypeDto
    {
        public int Id { get; init; }
        public string CargoTypeName { get; init; }
        public double CargoTypePrice { get; init; }
    }
}
