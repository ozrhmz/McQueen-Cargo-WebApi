using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CargoStatus
    {
        [Key]
        public int Id { get; set; }
        public string ShippingStatusName { get; set; }
        public string Information { get; set; }
    }
}
