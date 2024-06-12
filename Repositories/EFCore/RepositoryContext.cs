using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) :
            base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Neighbourhood> Neighbourhood { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<CargoStatus> CargoStatus { get; set; }
        public DbSet<CargoTransportationConditions> CargoTransportationConditions { get; set; }
        public DbSet<CargoType> CargoType { get; set; }
        public DbSet<CustomerMobil> CustomerMobil { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeesType> EmployeesType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Receiver> Receiver { get; set; }
        public DbSet<CallCourier> CallCourier { get; set; }
        public DbSet<CargoParcelType> CargoParcelType { get; set; }
        public DbSet<CargoMovement> CargoMovement { get; set; }
        public DbSet<Cargo> Cargo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
