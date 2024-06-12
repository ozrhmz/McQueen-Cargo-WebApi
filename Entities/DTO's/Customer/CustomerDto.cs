namespace Entities.DTO_s
{
    public record CustomerDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String TCNo { get; set; }
        public String NumberPhone { get; set; }
        public String CreatedDate { get; set; }
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
