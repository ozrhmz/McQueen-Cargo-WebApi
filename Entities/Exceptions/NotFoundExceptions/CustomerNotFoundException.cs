namespace Entities.Exceptions.NotFoundExceptions
{
    public sealed class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(int id) : base($"The customer with id:{id} could not found.") { }
        public CustomerNotFoundException(string TcNo) : base($"The customer with TcNo:{TcNo} could not found.") { }
        public CustomerNotFoundException() : base($"The customer could not found.") { }
    }
}
