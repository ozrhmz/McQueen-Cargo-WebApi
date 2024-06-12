using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class CustomerMobil
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TcNo { get; set; }
        public string NumberPhone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        //Navigation Prop
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<Receiver> Receivers { get; set; }
    }
}
