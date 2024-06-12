namespace Entities.Models
{
    public class Cargo
    {
        public int Id { get; set; }

        public int ReceiverId { get; set; }
        public Receiver Receiver { get; set; }

        public int? CustomerMobilId { get; set; }
        public CustomerMobil CustomerMobil { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerMobilAdressId { get; set; }

        public int CargoDepartureBranchId { get; set; }
        public Branch CargoDepartureBranch { get; set; }

        public int CargoArrivalBranchId { get; set; }
        public Branch CargoArrivalBranch { get; set; }

        public int CargoTransportationConditionsId { get; set; }
        public CargoTransportationConditions CargoTransportationConditions { get; set; }

        public int CargoTypeId { get; set; }
        public CargoType CargoType { get; set; }

        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public int CargoParcelTypeId { get; set; }
        public CargoParcelType cargoParcelType { get; set; }

        public int CargoStatusId { get; set; }
        public CargoStatus CargoStatus { get; set; }

        public double CargoDesi { get; set; }
        public DateTimeOffset CargoReleaseDate { get; set; } //Çıkış
        public DateTimeOffset? CargoEstimatedDeliveryDate { get; set; } //Tahmini Teslimat
        public DateTimeOffset? CargoDeliveryDate { get; set; }  // Teslimat
        public double Price { get; set; }
        public string? CargoTrackingNo { get; set; }

        public ICollection<CargoMovement> CargoMovements { get; set; }
    }
}
