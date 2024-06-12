using AutoMapper;
using Entities.DTO_s.CallCourier;
using Entities.DTO_s.Cargo;
using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CargoManager : ICargoService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public CargoManager(IRepositoryManager manager, IMapper mapper, ILoggerService logger)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CargoDto> CreateOneCargoAsync(CargoDtoForInsertion cargoDto)
        {
            var entity = _mapper.Map<Cargo>(cargoDto);
            _manager.Cargo.CreateOneCargo(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CargoDto>(entity);
        }

        public async Task<CargoDto> CreateOneCargoForCallCourierAsync(CallCourierDtoForUpdate callCourierDto)
        {
            if (callCourierDto == null)
                throw new CallCourierNotFoundException();

            var cargo = new CargoDtoForInsertion()
            {
                CargoDesi = callCourierDto.CargoDesi,
                CargoParcelTypeID = callCourierDto.CargoParcelTypeID,
                CargoReleaseDate = callCourierDto.CargoRealeseDate,
                CargoEstimatedDeliveryDate = callCourierDto.CargoRealeseDate.AddDays(3),
                CargoTransportationConditionsId = callCourierDto.CargoTransportationConditionsId,
                CargoTypeId = callCourierDto.CargoTypeId,
                CustomerMobilId = callCourierDto.CustomerMobilId,
                CustomerMobilAdressId = callCourierDto.CustomerMobilAdressId,
                PaymentTypeId = callCourierDto.PaymentTypeId,
                Price = callCourierDto.Price,
                ReceiverId = callCourierDto.ReceiverId,
                CargoStatusId = 1 // Kargoya Verildi.
            };

            var entity = _mapper.Map<Cargo>(cargo);
            _manager.Cargo.CreateOneCargoForCallCourier(entity);
            await _manager.SaveAsync();

            DateTimeOffset localNow = DateTimeOffset.Now;
            TimeSpan localOffset = TimeZoneInfo.Local.GetUtcOffset(localNow);
            DateTimeOffset adjustedLocalNow = new DateTimeOffset(localNow.DateTime, TimeSpan.Zero);


            var cargoMovement = new CargoMovement
            {
                BranchId = entity.CargoDepartureBranchId,
                CargoId = entity.Id,
                CargoStatusId = 1,
                Date = adjustedLocalNow
            };
            _manager.CargoMovement.CreateOneCargoMovement(cargoMovement);
            await _manager.SaveAsync();

            return _mapper.Map<CargoDto>(entity);
        }


        public async Task DeleteOneCargoAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCargoAndCheckExist(id, trackChanges);
            _manager.Cargo.DeleteOneCargo(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<CargoDto>> GetAllCargo()
        {
            var Cargo = await _manager.Cargo.GetAllCargoAsync();
            var CargoDtos = _mapper.Map<List<CargoDto>>(Cargo);
            return CargoDtos;
        }

        public async Task<List<CargoDto>> GetAllCargoByTCNoAsync(string TCNo, bool trackChanges)
        {
            var Cargoes = await _manager.Cargo.GetAllCargoByTCNoAsync(TCNo, trackChanges);
            var CargoesDto = _mapper.Map<List<CargoDto>>(Cargoes);
            return CargoesDto;
        }

        public async Task<CargoDto> GetOneCargoByIdAsync(int id, bool trackChanges)
        {
            var cc = await GetOneCargoAndCheckExist(id, trackChanges);
            var ccDto = _mapper.Map<CargoDto>(cc);
            return ccDto;
        }

        public async Task<CargoDto> GetOneCargoByTrackingNoAsync(string trackingNo, bool trackChanges)
        {
            var cargo = await _manager.Cargo.GetOneCargoByTrackingNoAsync(trackingNo, trackChanges);
            if (cargo == null)
                throw new CargoNotFoundException();

            var ccDto = _mapper.Map<CargoDto>(cargo);
            return ccDto;
        }

        public async Task UpdateOneCargoAsync(int id, CargoDtoForUpdate cargoDto, bool trackChanges)
        {
            var entity = await GetOneCargoAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Cargo>(cargoDto);
            _manager.Cargo.UpdateOneCargo(entity);
            await _manager.SaveAsync();
        }

        private async Task<Cargo> GetOneCargoAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.Cargo.GetOneCargoByIdAsync(id, trackChanges);
            if (entity is null)
                throw new CargoNotFoundException(id);

            return entity;
        }
    }
}
