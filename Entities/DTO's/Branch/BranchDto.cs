namespace Entities.DTO_s.Branch
{
    public record BranchDto
    {
        public int Id { get; init; }
        public string BranchName { get; init; }
        public int DistrictId { get; init; }
    }
}
