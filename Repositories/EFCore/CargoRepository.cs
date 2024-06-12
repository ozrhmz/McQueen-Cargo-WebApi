using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CargoRepository : RepositoryBase<Cargo>, ICargoRepository
    {
        public CargoRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCargo(Cargo cargo)
        {
            var adress = _context.Addresses.Where(x => x.Id.Equals(cargo.CustomerMobilAdressId)).FirstOrDefault();
            if (adress is null)
                throw new AddressNotFoundException();

            var branch = _context.Branch.Where(x => x.DistrictId.Equals(adress.DistrictId)).FirstOrDefault();
            if (branch is null)
                throw new BranchNotFoundException();

            var receiver = _context.Receiver.Where(x => x.Id == cargo.ReceiverId).FirstOrDefault();
            if (receiver is null)
                throw new ReceiverNotFoundException(receiver.Id);

            var ArrivalBranch = _context.Branch.Where(x => x.DistrictId.Equals(receiver.DistrictId)).FirstOrDefault();
            if (ArrivalBranch is null)
                throw new BranchNotFoundException();

            cargo.CargoArrivalBranchId = ArrivalBranch.Id;
            cargo.CargoEstimatedDeliveryDate = cargo.CargoReleaseDate.AddDays(3);

            var lastKT = _context.Cargo
                .Where(x => !string.IsNullOrEmpty(x.CargoTrackingNo))
                .OrderByDescending(x => x.Id) // Veya herhangi bir sıralama kriterine göre (örneğin: zaman, ID, vs.)
                .Select(x => x.CargoTrackingNo)
                .FirstOrDefault();

            string newCargoTrackingNo = "";
            if (!string.IsNullOrEmpty(lastKT))
            {
                // KT ile başlayan kısmı alıp, sonrasındaki sayıyı bir artırıyoruz
                string lastNumber = lastKT.Substring(2); // KT'yi atlayarak sayıyı alıyoruz
                if (int.TryParse(lastNumber, out int lastNumberInt))
                {
                    int nextNumber = lastNumberInt + 1;
                    newCargoTrackingNo = "KT" + nextNumber.ToString().PadLeft(lastNumber.Length, '0');
                }
            }
            cargo.CargoTrackingNo = newCargoTrackingNo;
            Create(cargo);
        }

        public void CreateOneCargoForCallCourier(Cargo cargo)
        {
            var adress = _context.Addresses.Where(x => x.Id.Equals(cargo.CustomerMobilAdressId)).FirstOrDefault();
            if (adress is null)
                throw new AddressNotFoundException();

            var DepartureBranchId = _context.Branch.Where(x => x.DistrictId.Equals(adress.DistrictId)).Select(x => x.Id).FirstOrDefault();
            if (DepartureBranchId == null || DepartureBranchId < 1)
                throw new BranchNotFoundException();

            var receiver = _context.Receiver.Where(x => x.Id == cargo.ReceiverId).FirstOrDefault();
            if (receiver is null)
                throw new ReceiverNotFoundException(receiver.Id);

            var ArrivalBranchId = _context.Branch.Where(x => x.DistrictId.Equals(receiver.DistrictId)).Select(x => x.Id).FirstOrDefault();
            if (ArrivalBranchId == null || ArrivalBranchId < 1)
                throw new BranchNotFoundException();

            cargo.CargoDepartureBranchId = DepartureBranchId;
            cargo.CargoArrivalBranchId = ArrivalBranchId;

            var lastKT = _context.Cargo
               .Where(x => !string.IsNullOrEmpty(x.CargoTrackingNo))
               .OrderByDescending(x => x.Id) // Veya herhangi bir sıralama kriterine göre (örneğin: zaman, ID, vs.)
               .Select(x => x.CargoTrackingNo)
               .FirstOrDefault();

            string newCargoTrackingNo = "";
            if (!string.IsNullOrEmpty(lastKT))
            {
                // KT ile başlayan kısmı alıp, sonrasındaki sayıyı bir artırıyoruz
                string lastNumber = lastKT.Substring(2); // KT'yi atlayarak sayıyı alıyoruz
                if (int.TryParse(lastNumber, out int lastNumberInt))
                {
                    int nextNumber = lastNumberInt + 1;
                    newCargoTrackingNo = "KT" + nextNumber.ToString().PadLeft(lastNumber.Length, '0');
                }
            }
            cargo.CargoTrackingNo = newCargoTrackingNo;
            Create(cargo);

        }

        public void DeleteOneCargo(Cargo cargo) => Delete(cargo);

        public async Task<IEnumerable<Cargo>> GetAllCargoAsync()
        {
            return await _context
                .Cargo
                .Include(c => c.CustomerMobil)
                .Include(c => c.Customer)
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
                .Include(x => x.CargoArrivalBranch)
                .Include(x => x.CargoDepartureBranch)
                .Include(x => x.cargoParcelType)
                .Include(x => x.CargoStatus)
                .ToListAsync();
        }

        public async Task<List<Cargo>> GetAllCargoByTCNoAsync(string TCNo, bool trackChanges)
        {

            var CustomerId = await _context.CustomerMobil
                .Where(x => x.TcNo.Equals(TCNo))
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            if (CustomerId == null)
                throw new CustomerNotFoundException(TCNo);

            var cargo = await _context.Cargo
            .Where(x => x.CustomerMobilId.Equals(CustomerId))
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
           .Include(x => x.CargoArrivalBranch)
           .Include(x => x.CargoDepartureBranch)
            .Include(x => x.cargoParcelType)
            .Include(x => x.CargoStatus)
            .ToListAsync();

            return cargo;
        }

        public async Task<Cargo> GetOneCargoByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(x => x.Id.Equals(id), trackChanges)
                .Include(c => c.CustomerMobil).ThenInclude(xx => xx.CustomerAddresses)
                .Include(c => c.Customer)
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
                .Include(x => x.CargoArrivalBranch)
                .Include(x => x.CargoDepartureBranch)
                .Include(x => x.cargoParcelType)
                .Include(x => x.CargoStatus)
                .SingleOrDefaultAsync();

        public async Task<Cargo> GetOneCargoByTrackingNoAsync(string trackingNo, bool trackChanges) =>
            await FindByCondition(x => x.CargoTrackingNo.Equals(trackingNo), trackChanges)
                .Include(c => c.CustomerMobil).ThenInclude(xx => xx.CustomerAddresses)
                .Include(c => c.Customer)
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
                .Include(x => x.CargoArrivalBranch)
                .Include(x => x.CargoDepartureBranch)
                .Include(x => x.cargoParcelType)
                .Include(x => x.CargoStatus)
                .SingleOrDefaultAsync();

        public void UpdateOneCargo(Cargo cargo) => Update(cargo);
    }
}
