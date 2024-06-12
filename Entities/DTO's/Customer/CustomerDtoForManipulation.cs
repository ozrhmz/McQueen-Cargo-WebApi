using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s
{
    public abstract record CustomerDtoForManipulation
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MinLength(2, ErrorMessage = "Name must consist of at least 2 character.")]
        [MaxLength(50, ErrorMessage = "Name must consist of at maximum 50 character.")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Surname is a required field.")]
        [MinLength(2, ErrorMessage = "Surname must consist of at least 2 character.")]
        [MaxLength(50, ErrorMessage = "Surname must consist of at maximum 50 character.")]
        public string Surname { get; init; }

        [Required(ErrorMessage = "TC No is a required field.")]
        [MinLength(11, ErrorMessage = "TC No must consist of at least 11 character.")]
        [MaxLength(11, ErrorMessage = "TC No must consist of at maximum 11 character.")]
        public string TCNo { get; init; }

        [Required(ErrorMessage = "Number Phone is a required field.")]
        [MinLength(11, ErrorMessage = "Number Phone must consist of at least 11 character.")]
        [MaxLength(11, ErrorMessage = "Number Phone must consist of at maximum 11 character.")]
        public string NumberPhone { get; init; }

        public string CreatedDate { get; init; }

        [Required(ErrorMessage = "Email is a required field.")]
        public String Email { get; init; }

        [Required(ErrorMessage = "BirthDate is a required field.")]
        public DateTime BirthDate { get; init; }
    }
}
