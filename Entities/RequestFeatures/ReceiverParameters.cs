namespace Entities.RequestFeatures
{
    public class ReceiverParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }

        public ReceiverParameters()
        {
            OrderBy = "id";    //Eğer sorgu esnasında sıralama verilmesse otomatik olarak id'ye göre sıralayacak. 
        }
    }
}
