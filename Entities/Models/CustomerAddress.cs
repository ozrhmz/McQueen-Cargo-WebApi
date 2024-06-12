
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class CustomerAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int? CustomerMobilId { get; set; }
        public CustomerMobil? CustomerMobil { get; set; }

        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }
    }
}
