using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;


namespace Repositories.EFCore
{
    public class CallCourierRepository : RepositoryBase<CallCourier>, ICallCourierRepository
    {
        public CallCourierRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCallCarier(CallCourier callCourier)
        {
            var adress = _context.Addresses.Where(x => x.Id.Equals(callCourier.CustomerMobilAdressId)).FirstOrDefault();
            if (adress is null)
                throw new AddressNotFoundException();

            var branch = _context.Branch.Where(x => x.DistrictId.Equals(adress.DistrictId)).FirstOrDefault();
            if (branch is null)
                throw new BranchNotFoundException();

            if (callCourier.CallCourierOk == true)
            {
                new CargoMovement()
                {
                    CargoStatusId = 7,
                    BranchId = branch.Id,
                    CallCourierId = callCourier.Id
                };
            }
            Create(callCourier);
        }

        public void DeleteOneCallCarier(CallCourier callCourier) => Delete(callCourier);

        public async Task<IEnumerable<CallCourier>> GetAllCallCarierAsync()
        {
            return await _context
                .CallCourier
                .Include(c => c.CustomerMobil)
                .Include(ctc => ctc.CargoTransportationConditions)
                .Include(ct => ct.CargoType)
                .Include(pt => pt.PaymentType)
                .Include(x => x.Receiver)
                    .ThenInclude(r => r.Country)
                .Include(x => x.Receiver)
                    .ThenInclude(p => p.Province)
                .Include(x => x.Receiver)
                    .ThenInclude(p => p.District)
                .Include(x => x.Receiver)
                    .ThenInclude(p => p.Neighbourhood)
                .Include(x => x.CargoParcelType)
                .ToListAsync();
        }

        public async Task<List<CallCourier>> GetAllCallCarierByTCNoAsync(string TCNo, bool trackChanges)
        {
            var CustomerId = await _context.CustomerMobil
                    .Where(x => x.TcNo.Equals(TCNo))
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();

            if (CustomerId == null)
                throw new CustomerNotFoundException(TCNo);


            var callCouriers = await _context.CallCourier
                .Where(x => x.CustomerMobilId.Equals(CustomerId) && x.CallCourierOk == false)
                 .Include(c => c.CustomerMobil)
                .Include(ctc => ctc.CargoTransportationConditions)
                .Include(ct => ct.CargoType)
                .Include(pt => pt.PaymentType)
                .Include(x => x.Receiver)
                    .ThenInclude(r => r.Country)
                .Include(x => x.Receiver)
                    .ThenInclude(p => p.Province)
                .Include(x => x.Receiver)
                    .ThenInclude(p => p.District)
                .Include(x => x.Receiver)
                    .ThenInclude(p => p.Neighbourhood)
                .Include(x => x.CargoParcelType)
                .ToListAsync();

            return callCouriers;
        }

        public async Task<CallCourier> GetOneCallCarierByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(x => x.Id.Equals(id) && x.CallCourierOk == false, trackChanges)
                .Include(c => c.CustomerMobil).ThenInclude(xx => xx.CustomerAddresses)
                .Include(ctc => ctc.CargoTransportationConditions)
                .Include(ct => ct.CargoType)
                .Include(pt => pt.PaymentType)
                .Include(x => x.Receiver)
                    .ThenInclude(r => r.Country)
                .Include(x => x.Receiver)
                    .ThenInclude(p => p.Province)
                .Include(x => x.Receiver)
                    .ThenInclude(p => p.District)
                .Include(x => x.Receiver)
                    .ThenInclude(p => p.Neighbourhood)
                .Include(x => x.CargoParcelType)
            .SingleOrDefaultAsync();

        public async void UpdateOneCallCarier(CallCourier callCourier) => Update(callCourier);

    }
}
