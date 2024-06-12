namespace Entities.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TcNo { get; set; }
        public string NumberPhone { get; set; }
        public string Password { get; set; }
        public int EmployeesTypeId { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public EmployeesType EmployeesType { get; set; }
    }
}
