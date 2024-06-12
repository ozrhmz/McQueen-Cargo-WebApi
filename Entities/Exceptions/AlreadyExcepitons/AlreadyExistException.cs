namespace Entities.Exceptions.AlreadyExcepitons
{
    public abstract class AlreadyExistException : Exception
    {
        protected AlreadyExistException(string message) : base(message) { }
    }
}

