using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class ReceiverRepository : RepositoryBase<Receiver>, IReceiverRepository
    {
        public ReceiverRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneReceiver(Receiver receiver) => Create(receiver);

        public void DeleteOneReceiver(Receiver receiver)
        {
            if (receiver.IsInActive == false)
            {
                receiver.IsInActive = true;
            }
        }

        public void DeleteReceivers(IEnumerable<Receiver> receivers)
        {
            try
            {

                var CargoIdList = new List<int>();
                foreach (Receiver receiver in receivers)
                {
                    var totalId = _context.Cargo.Where(x => x.ReceiverId == receiver.Id).Select(x => x.Id).ToList();
                    CargoIdList.AddRange(totalId);
                }
                var cargoMovementList = new List<int>();
                foreach (var item in CargoIdList)
                {
                    var cargoMovementListId = _context.CargoMovement.Where(x => x.CargoId == item).Select(x => x.Id).ToList();
                    cargoMovementList.AddRange(cargoMovementListId);
                }
                var cargoMovementsToDelete = _context.CargoMovement.Where(x => cargoMovementList.Contains(x.Id)).ToList();
                _context.CargoMovement.RemoveRange(cargoMovementsToDelete);
                DeleteRange(receivers);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IEnumerable<Receiver>> GetAllReceiverAsync(ReceiverParameters receiverParameters, bool trackChanges) =>
             await FindAll(trackChanges)
                  .Include(c => c.Country)
                  .Include(p => p.Province)
                  .Include(d => d.District)
                  .Include(n => n.Neighbourhood)
                  .Search(receiverParameters.SearchTerm)
                  .Sort(receiverParameters.OrderBy)
                  .ToListAsync();

        public async Task<IEnumerable<Receiver>> GetInactiveReceiversToDeleteAsync()
        {
            var sixMonthsAgo = DateTimeOffset.Now.AddMonths(6);

            return await FindByCondition(r => r.IsInActive == true && r.IsInActiveDate < sixMonthsAgo, trackChanges: false)
                .ToListAsync();
        }

        public async Task<IEnumerable<Receiver>> GetOneCustomerIdWithReceivers(int customerId, bool trackChanges)
        {
            return await _context.Receiver
                .Include(c => c.Country)
                .Include(p => p.Province)
                .Include(d => d.District)
                .Include(n => n.Neighbourhood)
                .Where(x => x.CustomerId == customerId && x.IsInActive == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<Receiver>> GetOneCustomerMobilIdWithReceivers(int customerMobilId, bool trackChanges)
        {
            return await _context.Receiver
                .Include(c => c.Country)
                .Include(p => p.Province)
                .Include(d => d.District)
                .Include(n => n.Neighbourhood)
                .Where(x => x.CustomerMobilId == customerMobilId && x.IsInActive == false)
                .ToListAsync();
        }

        public async Task<Receiver> GetOneReceiverByIdAsync(int id, bool trackChanges) =>
             await FindByCondition(c => c.Id.Equals(id), trackChanges)
                  .Include(a => a.Country)
                  .Include(a => a.Province)
                  .Include(a => a.District)
                  .Include(a => a.Neighbourhood)
                  .SingleOrDefaultAsync();

        public void UpdateOneReceiver(Receiver receiver) => Update(receiver);
    }
}
