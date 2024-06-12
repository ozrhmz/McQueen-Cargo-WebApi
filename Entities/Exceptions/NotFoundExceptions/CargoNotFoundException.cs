namespace Entities.Exceptions.NotFoundExceptions
{
    public sealed class CargoNotFoundException : NotFoundException
    {
        public CargoNotFoundException(int id) : base($"The cargo with id:{id} could not found.") { }
        public CargoNotFoundException() : base($"The cargo could not found.") { }
    }
}
