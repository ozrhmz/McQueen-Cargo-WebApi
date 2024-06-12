namespace Entities.Exceptions.AlreadyExcepitons
{
    public sealed class CustomerAlreadyExistException : AlreadyExistException
    {
        public CustomerAlreadyExistException(string TCNo) : base($"The user belonging to this {TCNo} already exists.") { }
    }
}