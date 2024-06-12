using AutoMapper;
using Entities.DTO_s.Employee;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class EmployeeTypeManager : IEmployeeTypeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public EmployeeTypeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeTypeDto>> GetAllEmployeeType()
        {
            var EmployeeType = await _manager.EmployeeType.GetAllEmployeeType();
            var EmployeeTypeDto = _mapper.Map<IEnumerable<EmployeeTypeDto>>(EmployeeType);
            return EmployeeTypeDto;
        }
    }
}
