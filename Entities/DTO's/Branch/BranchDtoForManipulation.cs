using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s.Branch
{
    public class BranchDtoForManipulation
    {
        public int Id { get; init; }

        [Required(ErrorMessage = "BranchName is a required field.")]
        [MinLength(2, ErrorMessage = "BranchName must consist of at least 2 character.")]
        [MaxLength(100, ErrorMessage = "BranchName must consist of at maximum 100 character.")]
        public string BranchName { get; init; }

        public int DistrictId { get; init; }
    }
}
