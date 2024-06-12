namespace Entities.RequestFeatures
{
    public class CustomerMobilParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }

        public CustomerMobilParameters()
        {
            OrderBy = "id";
        }
    }
}
