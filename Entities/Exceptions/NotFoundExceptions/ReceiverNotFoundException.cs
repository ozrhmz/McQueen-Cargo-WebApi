namespace Entities.Exceptions.NotFoundExceptions
{
    public sealed class ReceiverNotFoundException : NotFoundException
    {
        public ReceiverNotFoundException(int id) : base($"The receiver with id:{id} could not found.") { }
    }
}
