using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string DistrictName { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
