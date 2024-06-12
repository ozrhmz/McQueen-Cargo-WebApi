using Entities.DTO_s.Receiver;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts
{
    public interface IReceiverService
    {
        Task<IEnumerable<ExpandoObject>> GetAllReceiversAsync(ReceiverParameters receiverParameters, bool trackChanges);
        Task<ReceiverDto> GetOneReceiverByIdAsync(int id, bool trackChanges);
        Task<ReceiverDto> CreateOneReceiverAsync(ReceiverDtoForInsertion receiverDto);
        Task UpdateOneReceiverAsync(int id, ReceiverDtoForUpdate receiverDto, bool trackChanges);
        Task DeleteOneReceiverAsync(int id, bool trackChanges);
        Task<IEnumerable<ReceiverDto>> GetOneCustomerMobilIdWithReceiver(int customerMobilId, bool trackChanges);
        Task<IEnumerable<ReceiverDto>> GetOneCustomerIdWithReceiver(int customerId, bool trackChanges);
        Task DeleteInactiveReceiversAsync();
    }
}
