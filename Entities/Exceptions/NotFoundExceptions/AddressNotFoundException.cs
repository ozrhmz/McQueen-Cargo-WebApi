namespace Entities.Exceptions.NotFoundExceptions
{
    public sealed class AddressNotFoundException : NotFoundException
    {
        public AddressNotFoundException(int id) : base($"The address with id:{id} could not found.") { }
        public AddressNotFoundException() : base($"The address could not found.") { }
    }
}
