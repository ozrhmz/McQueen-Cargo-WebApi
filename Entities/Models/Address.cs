using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public int NeighbourhoodId { get; set; }
        public Neighbourhood Neighbourhood { get; set; }
        public string Street { get; set; }
        public string BuildingNo { get; set; }
        public string ApartmentNumber { get; set; }
        public int Floor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        //Navigation Prop
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
