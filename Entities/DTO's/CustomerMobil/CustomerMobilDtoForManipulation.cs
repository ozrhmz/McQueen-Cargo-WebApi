using Entities.Validations;

namespace Entities.DTO_s.CustomerMobil
{
    public record CustomerMobilDtoForManipulation
    {
        public string Name { get; init; }

        public string Surname { get; init; }

        public string TcNo { get; init; }

        public string NumberPhone { get; init; }

        public string Password { get; init; }

        public String Email { get; init; }

        public DateTime BirthDate { get; init; }

        public List<string> GetValidationMessages()
        {
            var errorMessages = new List<string>();

            string nameValidationMessage = CustomerMobilValidation.ValidateName(Name);
            if (!string.IsNullOrEmpty(nameValidationMessage))
            {
                errorMessages.Add(nameValidationMessage);
            }

            string surnameValidationMessage = CustomerMobilValidation.ValidateName(Surname);
            if (!string.IsNullOrEmpty(surnameValidationMessage))
            {
                errorMessages.Add(surnameValidationMessage);
            }

            string tcNoValidationMessage = CustomerMobilValidation.ValidateTcNo(TcNo);
            if (!string.IsNullOrEmpty(tcNoValidationMessage))
            {
                errorMessages.Add(tcNoValidationMessage);
            }

            string numberPhoneValidationMessage = CustomerMobilValidation.ValidatePhoneNumber(NumberPhone);
            if (!string.IsNullOrEmpty(numberPhoneValidationMessage))
            {
                errorMessages.Add(numberPhoneValidationMessage);
            }

            string passwordValidationMessage = CustomerMobilValidation.ValidatePassword(Password);
            if (!string.IsNullOrEmpty(passwordValidationMessage))
            {
                errorMessages.Add(passwordValidationMessage);
            }

            string emailValidationMessage = CustomerMobilValidation.ValidateEmail(Email);
            if (!string.IsNullOrEmpty(emailValidationMessage))
            {
                errorMessages.Add(emailValidationMessage);
            }

            string birthDateValidationMessage = CustomerMobilValidation.ValidateBirthday(BirthDate);
            if (!string.IsNullOrEmpty(birthDateValidationMessage))
            {
                errorMessages.Add(birthDateValidationMessage);
            }

            return errorMessages;
        }

        public bool Validate()
        {
            return GetValidationMessages().Count == 0;
        }
    }
}
