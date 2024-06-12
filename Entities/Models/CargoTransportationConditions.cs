using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CargoTransportationConditions
    {
        [Key]
        public int Id { get; set; }
        public string CargoTransportationConditionsName { get; set; }
        public double CargoTransportationConditionsPrice { get; set; }
    }
}
