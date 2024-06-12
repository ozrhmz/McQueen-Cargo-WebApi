using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class PaymentType
    {
        [Key]
        public int Id { get; set; }
        public string PaymentTypeName { get; set; }
    }
}
