using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        public string BranchName { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        //Navigation Prop
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
