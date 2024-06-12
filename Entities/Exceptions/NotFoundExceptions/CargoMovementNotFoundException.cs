

namespace Entities.Exceptions.NotFoundExceptions
{
    public sealed class CargoMovementNotFoundException : NotFoundException
    {
        public CargoMovementNotFoundException(int id) : base($"The Cargo Movement with id:{id} could not found.") { }
        public CargoMovementNotFoundException() : base($"The Cargo Movement could not found.") { }
    }
}
