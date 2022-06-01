using North.Core.Payments;

namespace North.Businesss.Services.Payment
{
    public interface IPaymentService
    {
        InstallmentModel CheckInstallments(string binNumber, decimal price);
        PaymentResponseModel Pay(PaymentModel model);
    }
}