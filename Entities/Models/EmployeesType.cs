using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class EmployeesType
    {
        [Key]
        public int Id { get; set; }
        public string EmployeesTypeName { get; set; }
    }
}
