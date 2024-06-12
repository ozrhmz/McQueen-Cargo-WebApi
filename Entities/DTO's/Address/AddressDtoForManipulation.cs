using Entities.Validations;
using System.ComponentModel.DataAnnotations;


namespace Entities.DTO_s
{
    public record AddressDtoForManipulation
    {
        public int CountryId { get; init; }

        public int ProvinceId { get; init; }

        public int DistrictId { get; init; }

        public int NeighbourhoodId { get; init; }

        public string Street { get; init; }

        public string BuildingNo { get; init; }

        public string Description { get; init; }

        [Required]
        public int Floor { get; init; }

        public string ApartmentNumber { get; init; }

        public string Title { get; init; }

        public List<string> GetValidationMessages()
        {
            var errorMessages = new List<string>();

            //string countryValidationMessage = AddressValidation.CountryIdForAddress(CountryId);
            //if (!string.IsNullOrEmpty(countryValidationMessage))
            //{
            //    errorMessages.Add(countryValidationMessage);
            //}

            //string provinceValidationMessage = AddressValidation.ProvinceIdForAddress(ProvinceId);
            //if (!string.IsNullOrEmpty(provinceValidationMessage))
            //{
            //    errorMessages.Add(provinceValidationMessage);
            //}

            //string districtValidationMessage = AddressValidation.DistrictIdForAddress(DistrictId);
            //if (!string.IsNullOrEmpty(districtValidationMessage))
            //{
            //    errorMessages.Add(districtValidationMessage);
            //}

            //string neighbourhoodValidationMessage = AddressValidation.NeighbourhoodIdForAddress(NeighbourhoodId);
            //if (!string.IsNullOrEmpty(neighbourhoodValidationMessage))
            //{
            //    errorMessages.Add(neighbourhoodValidationMessage);
            //}

            string streetValidationMessage = AddressValidation.ValidateStreet(Street);
            if (!string.IsNullOrEmpty(streetValidationMessage))
            {
                errorMessages.Add(streetValidationMessage);
            }

            string buildingNoValidationMessage = AddressValidation.ValidateBuildingNo(BuildingNo);
            if (!string.IsNullOrEmpty(buildingNoValidationMessage))
            {
                errorMessages.Add(buildingNoValidationMessage);
            }

            string aparmentNumberValidationMessage = AddressValidation.ValidateApartmentNumber(ApartmentNumber);
            if (!string.IsNullOrEmpty(aparmentNumberValidationMessage))
            {
                errorMessages.Add(aparmentNumberValidationMessage);
            }

            string titleValidationMessage = AddressValidation.ValidateTitle(Title);
            if (!string.IsNullOrEmpty(titleValidationMessage))
            {
                errorMessages.Add(titleValidationMessage);
            }

            return errorMessages;
        }

        public bool Validate()
        {
            return GetValidationMessages().Count == 0;
        }
    }
}
