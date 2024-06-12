using AutoMapper;
using Entities.DTO_s.Receiver;
using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services
{
    public class ReceiverManager : IReceiverService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        private readonly IDataShaper<ReceiverDto> _shaper;

        public ReceiverManager(IRepositoryManager manager, IMapper mapper, ILoggerService logger, IDataShaper<ReceiverDto> shaper)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
            _shaper = shaper;
        }

        public async Task<ReceiverDto> CreateOneReceiverAsync(ReceiverDtoForInsertion receiverDto)
        {
            var entity = _mapper.Map<Receiver>(receiverDto);
            _manager.Reciever.CreateOneReceiver(entity);
            await _manager.SaveAsync();
            return _mapper.Map<ReceiverDto>(entity);
        }

        public async Task DeleteOneReceiverAsync(int id, bool trackChanges)
        {
            var entity = await GetOneReceiverAndCheckExist(id, trackChanges);
            _manager.Reciever.DeleteOneReceiver(entity);
            _manager.Reciever.Update(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ExpandoObject>> GetAllReceiversAsync(ReceiverParameters receiverParameters, bool trackChanges)
        {
            var receivers = await _manager.Reciever.GetAllReceiverAsync(receiverParameters, trackChanges);
            var receiversDtos = _mapper.Map<List<ReceiverDto>>(receivers);
            return _shaper.ShapeData(receiversDtos, receiverParameters.Fields);
        }

        public async Task<IEnumerable<ReceiverDto>> GetOneCustomerMobilIdWithReceiver(int customerMobilId, bool trackChanges)
        {
            var receivers = await _manager.Reciever.GetOneCustomerMobilIdWithReceivers(customerMobilId, trackChanges);
            var receiversDtos = _mapper.Map<List<ReceiverDto>>(receivers);
            return receiversDtos;
        }

        public async Task<IEnumerable<ReceiverDto>> GetOneCustomerIdWithReceiver(int customerId, bool trackChanges)
        {
            var receivers = await _manager.Reciever.GetOneCustomerIdWithReceivers(customerId, trackChanges);
            var receiversDtos = _mapper.Map<List<ReceiverDto>>(receivers);
            return receiversDtos;
        }

        public async Task<ReceiverDto> GetOneReceiverByIdAsync(int id, bool trackChanges)
        {
            var receiver = await GetOneReceiverAndCheckExist(id, trackChanges);
            var receiverDto = _mapper.Map<ReceiverDto>(receiver);
            return receiverDto;
        }

        public async Task UpdateOneReceiverAsync(int id, ReceiverDtoForUpdate receiverDto, bool trackChanges)
        {
            var entity = await GetOneReceiverAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Receiver>(receiverDto);
            _manager.Reciever.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Receiver> GetOneReceiverAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.Reciever.GetOneReceiverByIdAsync(id, trackChanges);
            if (entity is null)
                throw new ReceiverNotFoundException(id);
            return entity;
        }

        public async Task DeleteInactiveReceiversAsync()
        {
            try
            {
                var inactiveReceivers = await _manager.Reciever.GetInactiveReceiversToDeleteAsync();
                _manager.Reciever.DeleteReceivers(inactiveReceivers);
                await _manager.SaveAsync();
            }
            catch (Exception ex)
            {
                // Hata mesajını loglama veya içteki istisnayı gösterme
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
            }
        }
    }
}
