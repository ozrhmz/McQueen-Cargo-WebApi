namespace Entities.Models
{
    public class CargoParcelType
    {
        public int Id { get; set; }
        public string CargoParcelTypeName { get; set; }
        public string MaxSize { get; set; }
        public string DesiSize { get; set; }
        public double Price { get; set; }
        public string Information { get; set; }
    }
}
