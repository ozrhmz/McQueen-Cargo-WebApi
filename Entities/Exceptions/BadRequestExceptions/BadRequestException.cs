

namespace Entities.Exceptions.BadRequestExceptions
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message) :
            base(message)
        {

        }
    }
}
