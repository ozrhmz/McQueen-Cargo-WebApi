using AutoMapper;
using Entities.DTO_s.CallCourier;
using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CallCourierManager : ICallCourierService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public CallCourierManager(IRepositoryManager manager, IMapper mapper, ILoggerService logger)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CallCourierDto> CreateOneCallCourierAsync(CallCourierDtoForInsertion callCourierDto)
        {
            var entity = _mapper.Map<CallCourier>(callCourierDto);
            _manager.CallCourier.CreateOneCallCarier(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CallCourierDto>(entity);
        }

        public async Task DeleteOneCallCourierAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCallCourierAndCheckExist(id, trackChanges);
            _manager.CallCourier.DeleteOneCallCarier(entity);
            await _manager.SaveAsync();
        }

        public async Task<List<CallCourierDto>> GetAllCallCarierByTCNoAsync(string TCNo, bool trackChanges)
        {
            var CallCouriers = await _manager.CallCourier.GetAllCallCarierByTCNoAsync(TCNo, trackChanges);
            var CallCouriersDto = _mapper.Map<List<CallCourierDto>>(CallCouriers);
            return CallCouriersDto;
        }

        public async Task<IEnumerable<CallCourierDto>> GetAllCallCourier()
        {
            var CallCouriers = await _manager.CallCourier.GetAllCallCarierAsync();
            var CallCouriersDto = _mapper.Map<List<CallCourierDto>>(CallCouriers);
            return CallCouriersDto;
        }

        public async Task<CallCourierDto> GetOneCallCarierByIdAsync(int id, bool trackChanges)
        {
            var cc = await GetOneCallCourierAndCheckExist(id, trackChanges);
            var ccDto = _mapper.Map<CallCourierDto>(cc);
            return ccDto;
        }

        public async Task UpdateOneCallCourierAsync(int id, CallCourierDtoForUpdate callCourierDto, bool trackChanges)
        {
            var entity = await GetOneCallCourierAndCheckExist(callCourierDto.Id, trackChanges);
            if (entity is null)
                throw new CallCourierNotFoundException(id);

            entity = _mapper.Map<CallCourier>(callCourierDto);
            _manager.CallCourier.UpdateOneCallCarier(entity);
            await _manager.SaveAsync();
        }

        private async Task<CallCourier> GetOneCallCourierAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.CallCourier.GetOneCallCarierByIdAsync(id, trackChanges);
            if (entity is null)
                throw new CallCourierNotFoundException(id);

            return entity;
        }
    }
}
