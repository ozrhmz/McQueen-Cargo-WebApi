namespace Entities.Exceptions.NotFoundExceptions
{
    public sealed class EmployeeNotFoundExceptions : NotFoundException
    {
        public EmployeeNotFoundExceptions(int id) : base($"The employee with id:{id} could not found.") { }
        public EmployeeNotFoundExceptions() : base($"The employee could not found.") { }
    }
}
