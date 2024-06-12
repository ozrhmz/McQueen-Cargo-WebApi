using System.ComponentModel.DataAnnotations;


namespace Entities.DTO_s.Branch
{
    public class BranchDtoForUpdate : BranchDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
