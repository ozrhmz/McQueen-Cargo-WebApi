using Entities.DTO_s.CallCourier;

namespace Services.Contracts
{
    public interface ICallCourierService
    {
        Task<IEnumerable<CallCourierDto>> GetAllCallCourier();
        Task<List<CallCourierDto>> GetAllCallCarierByTCNoAsync(string TCNo, bool trackChanges);
        Task<CallCourierDto> GetOneCallCarierByIdAsync(int id, bool trackChanges);
        Task<CallCourierDto> CreateOneCallCourierAsync(CallCourierDtoForInsertion callCourierDto);
        Task UpdateOneCallCourierAsync(int id, CallCourierDtoForUpdate callCourierDto, bool trackChanges);
        Task DeleteOneCallCourierAsync(int id, bool trackChanges);
    }
}
