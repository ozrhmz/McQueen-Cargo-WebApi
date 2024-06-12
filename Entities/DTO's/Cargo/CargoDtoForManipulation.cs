

namespace Entities.DTO_s.Cargo
{
    public record CargoDtoForManipulation
    {
        public int Id { get; init; }
        public int? CustomerMobilId { get; init; }
        public int? CustomerId { get; init; }
        public int CustomerMobilAdressId { get; init; }
        public int CargoDepartureBranchId { get; init; }
        public int CargoArrivalBranchId { get; init; }
        public int ReceiverId { get; init; }
        //public int ReceiverCountryId { get; init; }
        //public int ReceiverProvinceId { get; init; }
        //public int ReceiverDistrictId { get; init; }
        //public int ReceiverNeighbourhoodId { get; init; }
        //public string ReceiverStreet { get; init; }
        //public string ReceiverBuildingNo { get; init; }
        //public int Floor { get; init; }
        //public string ReceiverApartmentNumber { get; init; }
        public int CargoParcelTypeID { get; init; }
        public int PaymentTypeId { get; init; }
        public int CargoTransportationConditionsId { get; init; }
        public int CargoTypeId { get; init; }
        public double CargoDesi { get; init; }
        public int CargoStatusId { get; init; }
        public DateTimeOffset CargoReleaseDate { get; init; } //Çıkış
        public DateTimeOffset? CargoEstimatedDeliveryDate { get; init; } //Tahmini Teslimat
        public DateTimeOffset? CargoDeliveryDate { get; init; }  // Teslimat
        public double Price { get; init; }
        public string? CargoTrackingNo { get; init; }
    }
}
