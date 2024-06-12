namespace Entities.Validations
{
    public static class ReceiverValidation
    {
        public static string ValidateNameForReceiver(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 2 || name.Length > 50)
            {
                return "Name must be between 2 and 50 characters.";
            }
            return string.Empty;
        }

        public static string ValidateSurnameForReceiver(string Surname)
        {
            if (string.IsNullOrEmpty(Surname) || Surname.Length < 2 || Surname.Length > 50)
            {
                return "Surname must be between 2 and 50 characters.";
            }
            return string.Empty;
        }

        public static string ValidateNumberPhoneForReceiver(string NumberPhone)
        {
            if (string.IsNullOrEmpty(NumberPhone) || NumberPhone.Length != 11)
            {
                return "Number phone must be 11 digits";
            }
            return string.Empty;
        }
    }
}
