using Entities.Validations;

namespace Entities.DTO_s.Receiver
{
    public record ReceiverDtoForManipulation
    {
        public string NameSurname { get; init; }
        public string? Email { get; init; }
        public string NumberPhone { get; init; }
        public int CountryId { get; init; }
        public string? CountryName { get; init; }
        public int ProvinceId { get; init; }
        public string? ProvinceName { get; init; }
        public int DistrictId { get; init; }
        public string? DistrictName { get; init; }
        public int NeighbourhoodId { get; init; }
        public string? NeighbourhoodName { get; init; }
        public string Street { get; init; }
        public string BuildingNo { get; init; }
        public int Floor { get; init; }
        public string ApartmentNumber { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }

        public int? CustomerMobilId { get; init; }
        public int? CustomerId { get; init; }

        public List<string> GetValidationMessages()
        {
            var errorMessages = new List<string>();

            string nameValidationMessage = ReceiverValidation.ValidateNameForReceiver(NameSurname);
            if (!string.IsNullOrEmpty(nameValidationMessage))
            {
                errorMessages.Add(nameValidationMessage);
            }

            //string surnameValidationMessage = ReceiverValidation.ValidateSurnameForReceiver(Surname);
            //if (!string.IsNullOrEmpty(surnameValidationMessage))
            //{
            //    errorMessages.Add(surnameValidationMessage);
            //}

            string numberPhoneValidationMessage = ReceiverValidation.ValidateNumberPhoneForReceiver(NumberPhone);
            if (!string.IsNullOrEmpty(numberPhoneValidationMessage))
            {
                errorMessages.Add(numberPhoneValidationMessage);
            }
            return errorMessages;
        }

        public bool Validate()
        {
            return GetValidationMessages().Count == 0;
        }
    }
}
