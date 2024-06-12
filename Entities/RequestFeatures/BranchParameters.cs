namespace Entities.RequestFeatures
{
    public class BranchParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }

        public BranchParameters()
        {
            OrderBy = "id";
        }
    }
}
