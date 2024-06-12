using AutoMapper;
using Entities.DTO_s.Branch;
using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services
{
    public class BranchManager : IBranchService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        private readonly IDataShaper<BranchDto> _shaper;

        public BranchManager(IRepositoryManager manager, IMapper mapper, ILoggerService logger, IDataShaper<BranchDto> shaper)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
            _shaper = shaper;
        }

        public async Task<BranchDto> CreateOneBracnhAsync(BranchDtoForInsertion branchDto)
        {
            var entity = _mapper.Map<Branch>(branchDto);
            _manager.Branch.CreateOneBranch(entity);
            await _manager.SaveAsync();
            return _mapper.Map<BranchDto>(entity);
        }

        public async Task DeleteOneBranchAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBranchAndCheckExist(id, trackChanges);
            _manager.Branch.DeleteOneBranch(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ExpandoObject>> GetAllBranchesAsync(BranchParameters branchParameters, bool trackChanges)
        {
            var branches = await _manager.Branch.GetAllBranchesAsync(branchParameters, trackChanges);
            var branchesDto = _mapper.Map<IEnumerable<BranchDto>>(branches);
            var shapedData = _shaper.ShapeData(branchesDto, branchParameters.Fields);
            return shapedData;
        }

        public async Task<BranchDto> GetOneBranchByIdAsync(int id, bool trackChanges)
        {
            var branch = await GetOneBranchAndCheckExist(id, trackChanges);
            return _mapper.Map<BranchDto>(branch);
        }

        public async Task UpdateOneBranchAsync(int id, BranchDtoForUpdate branchDto, bool trackChanges)
        {
            var entity = await GetOneBranchAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Branch>(branchDto);
            _manager.Branch.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Branch> GetOneBranchAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.Branch.GetOneBranchByIdAsync(id, trackChanges);
            if (entity is null)
                throw new BranchNotFoundException(id);
            return entity;
        }
    }
}
