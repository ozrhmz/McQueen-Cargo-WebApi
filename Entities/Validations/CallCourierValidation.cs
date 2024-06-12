namespace Entities.Validations
{
    public static class CallCourierValidation
    {
        public static string ReceiverIdForCallCourier(int receiverId)
        {
            if (receiverId <= 0)
            {
                return "Receiver ID must be a positive integer.";
            }
            return string.Empty;
        }

        public static string PaymentTypeIdForCallCourier(int PaymentTypeId)
        {
            if (PaymentTypeId <= 0)
            {
                return "Payment Type ID must be a positive integer.";
            }
            return string.Empty;
        }

        public static string CargoParcelTypeIdForCallCourier(int CargoParcelTypeId)
        {
            if (CargoParcelTypeId <= 0)
            {
                return "Cargo Parcel Type ID must be a positive integer.";
            }
            return string.Empty;
        }

        public static string CargoTransportationConditionsIdForCallCourier(int CargoTransportationConditionsId)
        {
            if (CargoTransportationConditionsId <= 0)
            {
                return "Transport Conditions ID must be a positive integer.";
            }
            return string.Empty;
        }

        public static string CargoTypeIdForCallCourier(int CargoTypeId)
        {
            if (CargoTypeId <= 0)
            {
                return "Cargo Type ID must be a positive integer.";
            }
            return string.Empty;
        }

        public static string CargoDesiForCallCourier(double CargoDesi)
        {
            if (CargoDesi <= 0)
            {
                return "Cargo Desi must be a positive integer.";
            }
            return string.Empty;
        }

        public static string CargoRealeseDateForCallCourier(DateTimeOffset CargoRealeseDate)
        {
            if (CargoRealeseDate <= DateTimeOffset.Now.AddDays(-1))
            {
                return "Shipping release date cannot be less than today.";
            }
            return string.Empty;
        }

        public static string PriceForCallCourier(double Price)
        {
            if (Price <= 0)
            {
                return "Price must be a positive integer.";
            }
            return string.Empty;
        }

        public static string CallCourierOkForCallCourier(bool CallCourierOk)
        {
            if (CallCourierOk == null)
            {
                return "Call Courier Ok must be a value";
            }
            return string.Empty;
        }

        public static string addresIdForCallCourier(int addresId)
        {
            if (addresId <= 0)
            {
                return "Customer Addres must be a value";
            }
            return string.Empty;
        }
    }
}
