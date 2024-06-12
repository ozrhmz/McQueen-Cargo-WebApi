using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CargoMovement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int? CargoId { get; set; }
        public Cargo? Cargo { get; set; }

        public int? CallCourierId { get; set; }
        public CallCourier? CallCourier { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int CargoStatusId { get; set; }
        public CargoStatus CargoStatus { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
