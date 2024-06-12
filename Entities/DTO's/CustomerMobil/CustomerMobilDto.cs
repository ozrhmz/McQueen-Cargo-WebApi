
namespace Entities.DTO_s.CustomerMobil
{
    public record CustomerMobilDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string TcNo { get; init; }
        public string NumberPhone { get; init; }
        public string Password { get; init; }
        public String Email { get; init; }
        public DateTime BirthDate { get; init; }
    }
}
