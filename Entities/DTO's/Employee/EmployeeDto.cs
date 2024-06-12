

namespace Entities.DTO_s.Employee
{
    public record EmployeeDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string TcNo { get; init; }
        public string NumberPhone { get; init; }
        public string Password { get; init; }
        public int EmployeesTypeId { get; init; }
        public int BranchId { get; init; }
    }
}
