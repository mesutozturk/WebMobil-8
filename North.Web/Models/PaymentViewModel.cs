﻿using North.Core.Payments;

namespace North.Web.Models
{
    public class PaymentViewModel
    {
        public CardModel CardModel { get; set; }
        public AddressModel? AddressModel { get; set; }
        public BasketModel BasketModel { get; set; }
        public decimal Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public int Installment { get; set; }
    }
}
