namespace Entities.Exceptions.NotFoundExceptions
{
    public sealed class BranchNotFoundException : NotFoundException
    {
        public BranchNotFoundException(int id) : base($"The branch with id:{id} could not found.") { }
        public BranchNotFoundException() : base($"The branch could not found.") { }
    }
}
