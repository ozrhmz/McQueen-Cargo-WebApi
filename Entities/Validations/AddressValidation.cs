namespace Entities.Validations
{
    public static class AddressValidation
    {
        public static string CountryIdForAddress(int countryId)
        {
            if (countryId <= 0)
            {
                return "Country ID must be a positive integer.";
            }
            return string.Empty;
        }

        public static string ProvinceIdForAddress(int provinceId)
        {
            if (provinceId <= 0)
            {
                return "Province ID must be a positive integer.";
            }
            return string.Empty;
        }

        public static string DistrictIdForAddress(int districtId)
        {
            if (districtId <= 0)
            {
                return "District ID must be a positive integer.";
            }
            return string.Empty;
        }

        public static string NeighbourhoodIdForAddress(int neighbourhoodId)
        {
            if (neighbourhoodId <= 0)
            {
                return "Neighbourhood ID must be a positive integer.";
            }
            return string.Empty;
        }

        public static string ValidateStreet(string street)
        {
            if (string.IsNullOrEmpty(street) || street.Length < 2 || street.Length > 100)
            {
                return "Street must be between 2 and 100 characters.";
            }
            return string.Empty;
        }

        public static string ValidateBuildingNo(string buildingNo)
        {
            if (string.IsNullOrEmpty(buildingNo) || buildingNo.Length < 1 || buildingNo.Length > 100)
            {
                return "Building No must be between 2 and 100 characters.";
            }
            return string.Empty;
        }

        public static string ValidateApartmentNumber(string apartmentNumber)
        {
            if (string.IsNullOrEmpty(apartmentNumber) || apartmentNumber.Length < 1 || apartmentNumber.Length > 100)
            {
                return "Aparmant Number must be between 2 and 100 characters.";
            }
            return string.Empty;
        }

        public static string ValidatePostCode(string postCode)
        {
            if (string.IsNullOrEmpty(postCode) || postCode.Length != 5)
            {
                return "Posta code must be 5 characters";
            }
            return string.Empty;
        }

        public static string ValidateTitle(string title)
        {
            if (string.IsNullOrEmpty(title) || title.Length < 1 || title.Length > 100)
            {
                return "Title must be between 1 and 100 characters.";
            }
            return string.Empty;
        }

    }
}
