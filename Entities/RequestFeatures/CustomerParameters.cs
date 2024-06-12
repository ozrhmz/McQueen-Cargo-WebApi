namespace Entities.RequestFeatures
{
    public class CustomerParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }

        public CustomerParameters()
        {
            OrderBy = "id";    //Eğer sorgu esnasında sıralama verilmesse otomatik olarak id'ye göre sıralayacak. 
        }
    }
}
