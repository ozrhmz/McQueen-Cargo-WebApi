#region test
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace Entities.Validations
//{
//    public static class CustomerMobilValidation
//    {
//        public static bool ValidateName(string name)
//        {
//            return !string.IsNullOrEmpty(name) && name.Length >= 2 && name.Length <= 50;
//        }

//        public static bool ValidateTcNo(string tcNo)
//        {
//            return !string.IsNullOrEmpty(tcNo) && tcNo.Length == 11;
//        }

//        public static bool ValidatePhoneNumber(string phoneNumber)
//        {
//            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == 11;
//        }

//        public static bool ValidatePassword(string password)
//        {
//            return !string.IsNullOrEmpty(password) && password.Length >= 6 && password.Length <= 40;
//        }

//        public static bool ValidateEmail(string email)
//        {
//            if (string.IsNullOrEmpty(email))
//                return false;

//            var emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
//            return emailRegex.IsMatch(email);
//        }

//        public static bool ValidateBirthday(DateTime birthday)
//        {
//            return birthday <= DateTime.Now;
//        }
//    }
//}
#endregion
using System.Text.RegularExpressions;

namespace Entities.Validations
{
    public static class CustomerMobilValidation
    {
        public static string ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 2 || name.Length > 50)
            {
                return "Name must be between 2 and 50 characters.";
            }
            return string.Empty;
        }

        public static string ValidateTcNo(string tcNo)
        {
            if (string.IsNullOrEmpty(tcNo) || tcNo.Length != 11)
            {
                return "TC No must be 11 characters.";
            }
            return string.Empty;
        }

        public static string ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 11)
            {
                return "Phone number must be 11 characters.";
            }
            return string.Empty;
        }

        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 6 || password.Length > 40)
            {
                return "Password must be between 6 and 40 characters.";
            }
            return string.Empty;
        }

        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "Email is required.";
            }

            var emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            if (!emailRegex.IsMatch(email))
            {
                return "Invalid email format.";
            }
            return string.Empty;
        }

        public static string ValidateBirthday(DateTime birthday)
        {
            if (birthday > DateTime.Now)
            {
                return "Birthday cannot be in the future.";
            }
            return string.Empty;
        }
    }
}