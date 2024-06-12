namespace Entities.Exceptions.NotFoundExceptions
{
    public sealed class CallCourierNotFoundException : NotFoundException
    {
        public CallCourierNotFoundException(int id) : base($"The call courier with id:{id} could not found.") { }
        public CallCourierNotFoundException() : base($"The call courier could not found.") { }
    }
}
