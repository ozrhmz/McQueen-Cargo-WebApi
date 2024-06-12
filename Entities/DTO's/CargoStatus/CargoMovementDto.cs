namespace Entities.DTO_s.CargoStatus
{
    public record CargoMovementDto
    {
        public int Id { get; init; }
        public int? CargoId { get; init; }
        public string? CargoTrackingNo { get; set; }

        public int? CallCourierId { get; init; }

        public int BranchId { get; init; }
        public String? CargoBranchName { get; init; }

        public int CargoStatusId { get; init; }
        public string? CargoStatusName { get; init; }

        public DateTimeOffset Date { get; init; }
    }
}
