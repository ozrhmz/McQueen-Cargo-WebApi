
namespace Entities.DTO_s.CallCourier
{
    public record CallCourierDto
    {
        public int Id { get; init; }

        public int CustomerMobilId { get; init; }
        public String? CustomerName { get; init; }
        public String? CustomerSurname { get; init; }
        public int CustomerMobilAdressId { get; init; }

        public int ReceiverId { get; init; }
        public string ReceiverNameSurname { get; init; }
        public int ReceiverCountryId { get; init; }
        public string? ReceiverCountryName { get; init; }
        public int ReceiverProvinceId { get; init; }
        public string? ReceiverProvinceName { get; init; }
        public int ReceiverDistrictId { get; init; }
        public string? ReceiverDistrictName { get; init; }
        public int ReceiverNeighbourhoodId { get; init; }
        public string? ReceiverNeighbourhoodName { get; init; }
        public string ReceiverStreet { get; init; }
        public string ReceiverBuildingNo { get; init; }
        public int Floor { get; init; }
        public string ReceiverApartmentNumber { get; init; }

        public int CargoParcelTypeID { get; init; }
        public string? CargoParcelTypeName { get; init; }

        public int PaymentTypeId { get; init; }
        public string? PaymentTypeName { get; init; }

        public int CargoTransportationConditionsId { get; init; }
        public string? CargoTransportationConditionsName { get; init; }

        public int CargoTypeId { get; init; }
        public string? CargoTypeName { get; init; }

        public bool CallCourierOk { get; init; }
        public double CargoDesi { get; init; }
        public DateTimeOffset CargoRealeseDate { get; init; }
        public double Price { get; init; }
    }
}
