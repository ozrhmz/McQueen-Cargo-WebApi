using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }
        public string ProvinceName { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
