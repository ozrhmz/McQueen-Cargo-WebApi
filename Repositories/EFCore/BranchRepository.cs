using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBranch(Branch branch) => Create(branch);

        public void DeleteOneBranch(Branch branch) => Delete(branch);

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync(BranchParameters branchParameters, bool trackChanges) =>
             await FindAll(trackChanges)
                  .Search(branchParameters.SearchTerm)
                  .Sort(branchParameters.OrderBy)
                  .ToListAsync();

        public async Task<Branch> GetOneBranchByIdAsync(int id, bool trackChanges) =>
             await FindByCondition(c => c.Id.Equals(id), trackChanges)
                  .SingleOrDefaultAsync();

        public void UpdateOneBranch(Branch branch) => Update(branch);
    }
}
