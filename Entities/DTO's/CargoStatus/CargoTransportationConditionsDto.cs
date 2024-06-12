namespace Entities.DTO_s.CargoStatus
{
    public record CargoTransportationConditionsDto
    {
        public int Id { get; init; }
        public string CargoTransportationConditionsName { get; init; }
        public double CargoTransportationConditionsPrice { get; init; }
    }
}
