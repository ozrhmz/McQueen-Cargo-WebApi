namespace Entities.RequestFeatures
{
    public class AddressParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }

        public AddressParameters()
        {
            OrderBy = "id";
        }
    }
}
