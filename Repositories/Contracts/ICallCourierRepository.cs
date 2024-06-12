using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICallCourierRepository : IRepositoryBase<CallCourier>
    {
        Task<IEnumerable<CallCourier>> GetAllCallCarierAsync();
        Task<List<CallCourier>> GetAllCallCarierByTCNoAsync(string TCNo, bool trackChanges);
        Task<CallCourier> GetOneCallCarierByIdAsync(int id, bool trackChanges);
        void CreateOneCallCarier(CallCourier callCourier);
        void UpdateOneCallCarier(CallCourier callCourier);
        void DeleteOneCallCarier(CallCourier callCourier);
    }
}
