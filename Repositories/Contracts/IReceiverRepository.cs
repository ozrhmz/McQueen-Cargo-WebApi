using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface IReceiverRepository : IRepositoryBase<Receiver>
    {
        Task<IEnumerable<Receiver>> GetAllReceiverAsync(ReceiverParameters receiverParameters, bool trackChanges);
        Task<Receiver> GetOneReceiverByIdAsync(int id, bool trackChanges);
        void CreateOneReceiver(Receiver receiver);
        void UpdateOneReceiver(Receiver receiver);
        void DeleteOneReceiver(Receiver receiver);
        Task<IEnumerable<Receiver>> GetOneCustomerMobilIdWithReceivers(int customerMobilId, bool trackChanges); //CustomerMobilId'ye göre Alıcılar
        Task<IEnumerable<Receiver>> GetOneCustomerIdWithReceivers(int customerId, bool trackChanges); //CustomerId'ye göre Alıcılar
        Task<IEnumerable<Receiver>> GetInactiveReceiversToDeleteAsync();
        void DeleteReceivers(IEnumerable<Receiver> receivers);
    }
}
