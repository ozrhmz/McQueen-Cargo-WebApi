using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface IBranchRepository : IRepositoryBase<Branch>
    {
        Task<IEnumerable<Branch>> GetAllBranchesAsync(BranchParameters branchParameters, bool trackChanges); //Tüm şubeler
        Task<Branch> GetOneBranchByIdAsync(int id, bool trackChanges); //ŞubeId
        void CreateOneBranch(Branch branch); //Create
        void UpdateOneBranch(Branch branch); //Update
        void DeleteOneBranch(Branch branch); //Delete
    }
}
