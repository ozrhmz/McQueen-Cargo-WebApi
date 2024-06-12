namespace Entities.Exceptions.NotFoundExceptions
{
    public sealed class AddressNotFoundWithCustomer : NotFoundException
    {
        public AddressNotFoundWithCustomer(int customerId, int addressId) : base($"The customer with id :{customerId} and address with id:{addressId} and could not found.") { }
    }
}
