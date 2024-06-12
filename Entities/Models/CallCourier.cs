using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CallCourier
    {
        [Key]
        public int Id { get; set; }
        public int CustomerMobilId { get; set; }
        public CustomerMobil CustomerMobil { get; set; }
        public int CustomerMobilAdressId { get; set; }

        public int ReceiverId { get; set; }
        public Receiver Receiver { get; set; }

        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public int CargoParcelTypeID { get; init; }
        public CargoParcelType CargoParcelType { get; set; }

        public int CargoTransportationConditionsId { get; set; }
        public CargoTransportationConditions CargoTransportationConditions { get; set; }

        public int CargoTypeId { get; set; }
        public CargoType CargoType { get; set; }

        public double CargoDesi { get; set; }
        public DateTimeOffset CargoRealeseDate { get; set; }
        public double Price { get; set; }
        public bool CallCourierOk { get; set; }
    }
}
