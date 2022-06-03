using North.Core.Payments;

namespace North.Web.Models
{
    public class PaymentViewModel
    {
        public CardModel CardModel { get; set; }
        public List<CartModel> Carts { get; set; } = new();
        public int Installment { get; set; }
    }
}