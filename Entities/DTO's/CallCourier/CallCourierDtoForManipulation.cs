using Entities.Validations;

namespace Entities.DTO_s.CallCourier
{
    public record CallCourierDtoForManipulation
    {
        public int Id { get; init; }
        public int CustomerMobilId { get; init; }
        public int CustomerMobilAdressId { get; init; }
        public int ReceiverId { get; init; }
        public int PaymentTypeId { get; init; }
        public int CargoParcelTypeID { get; init; }
        public int CargoTransportationConditionsId { get; init; }
        public int CargoTypeId { get; init; }
        public double CargoDesi { get; init; }
        public DateTimeOffset CargoRealeseDate { get; init; }
        public double Price { get; init; }
        public bool CallCourierOk { get; init; }


        public List<string> GetValidationMessages()
        {
            var errorMessages = new List<string>();

            string ReceiverValidationMessage = CallCourierValidation.ReceiverIdForCallCourier(ReceiverId);
            if (!string.IsNullOrEmpty(ReceiverValidationMessage))
            {
                errorMessages.Add(ReceiverValidationMessage);
            }

            string PaymentTypeIdValidationMessage = CallCourierValidation.PaymentTypeIdForCallCourier(PaymentTypeId);
            if (!string.IsNullOrEmpty(PaymentTypeIdValidationMessage))
            {
                errorMessages.Add(PaymentTypeIdValidationMessage);
            }

            string ParcelTypeIdValidationMessage = CallCourierValidation.CargoParcelTypeIdForCallCourier(CargoParcelTypeID);
            if (!string.IsNullOrEmpty(ParcelTypeIdValidationMessage))
            {
                errorMessages.Add(ParcelTypeIdValidationMessage);
            }

            string CargoTransportationConditionsIdValidationMessage = CallCourierValidation.CargoTransportationConditionsIdForCallCourier(CargoTransportationConditionsId);
            if (!string.IsNullOrEmpty(CargoTransportationConditionsIdValidationMessage))
            {
                errorMessages.Add(CargoTransportationConditionsIdValidationMessage);
            }

            string CargoDesiValidationMessage = CallCourierValidation.CargoDesiForCallCourier(CargoDesi);
            if (!string.IsNullOrEmpty(CargoDesiValidationMessage))
            {
                errorMessages.Add(CargoDesiValidationMessage);
            }

            string CargoRealeseDateValidationMessage = CallCourierValidation.CargoRealeseDateForCallCourier(CargoRealeseDate);
            if (!string.IsNullOrEmpty(CargoRealeseDateValidationMessage))
            {
                errorMessages.Add(CargoRealeseDateValidationMessage);
            }

            string PriceValidationMessage = CallCourierValidation.PriceForCallCourier(Price);
            if (!string.IsNullOrEmpty(PriceValidationMessage))
            {
                errorMessages.Add(PriceValidationMessage);
            }

            string CallCourierOkValidationMessage = CallCourierValidation.CallCourierOkForCallCourier(CallCourierOk);
            if (!string.IsNullOrEmpty(CallCourierOkValidationMessage))
            {
                errorMessages.Add(CallCourierOkValidationMessage);
            }

            string CargoTypeIdValidationMessage = CallCourierValidation.CargoTypeIdForCallCourier(CargoTypeId);
            if (!string.IsNullOrEmpty(CargoTypeIdValidationMessage))
            {
                errorMessages.Add(CargoTypeIdValidationMessage);
            }

            string AdressIdValidationMessage = CallCourierValidation.addresIdForCallCourier(CustomerMobilAdressId);
            if (!string.IsNullOrEmpty(AdressIdValidationMessage))
            {
                errorMessages.Add(AdressIdValidationMessage);
            }

            return errorMessages;
        }

        public bool Validate()
        {
            return GetValidationMessages().Count == 0;
        }
    }
}
