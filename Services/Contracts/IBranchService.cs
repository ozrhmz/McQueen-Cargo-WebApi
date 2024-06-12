using Entities.DTO_s.Branch;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts
{
    public interface IBranchService
    {
        Task<IEnumerable<ExpandoObject>> GetAllBranchesAsync(BranchParameters branchParameters, bool trackChanges);
        Task<BranchDto> GetOneBranchByIdAsync(int id, bool trackChanges);
        Task<BranchDto> CreateOneBracnhAsync(BranchDtoForInsertion branchDto);
        Task UpdateOneBranchAsync(int id, BranchDtoForUpdate branchDto, bool trackChanges);
        Task DeleteOneBranchAsync(int id, bool trackChanges);
    }
}
