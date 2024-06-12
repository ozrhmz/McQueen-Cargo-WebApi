using AutoMapper;
using Entities.DTO_s.CargoStatus;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class PaymentTypeManager : IPaymentTypeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public PaymentTypeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentTypeDto>> GetAllPaymentType()
        {
            var PaymentType = await _manager.PaymentType.GetAllPaymentType();
            var PaymentTypeDto = _mapper.Map<IEnumerable<PaymentTypeDto>>(PaymentType);
            return PaymentTypeDto;
        }
    }
}
