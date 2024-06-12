namespace Entities.Models
{
    public class Neighbourhood
    {
        public int Id { get; set; }
        public string NeighbourhoodName { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
