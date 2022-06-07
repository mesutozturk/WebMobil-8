using AutoMapper;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.Extensions.Configuration;
using MUsefulMethods;
using North.Core.Payments;
using System.Globalization;

namespace North.Businesss.Services.Payment
{
    public class IyzicoPaymentOptions : Options
    {
        public const string Key = "IyzicoOptions";
        public string ThreedsCallbackUrl { get; set; }
    }
    public class IyzicoPaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IyzicoPaymentOptions _options;
        private readonly IMapper _mapper;
        public IyzicoPaymentService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
            var section = _configuration.GetSection(IyzicoPaymentOptions.Key);
            _options = new IyzicoPaymentOptions()
            {
                ApiKey = section["ApiKey"],
                SecretKey = section["SecretKey"],
                BaseUrl = section["BaseUrl"]
            };
        }
        private string GenerateConversationId()
        {
            return StringHelpers.GenerateUniqueCode();
        }
        public InstallmentModel CheckInstallments(string binNumber, decimal price)
        {
            var conversationId = GenerateConversationId();
            if(binNumber.Length<=6)
                throw new Exception("Bin number must be at least 6 characters");
            var request = new RetrieveInstallmentInfoRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = conversationId,
                BinNumber = binNumber.Substring(0, 6),
                Price = price.ToString(new CultureInfo("en-US")),
            };

            var result = InstallmentInfo.Retrieve(request, _options);
            if (result.Status == "failure")
            {
                throw new Exception(result.ErrorMessage);
            }

            if (result.ConversationId != conversationId)
            {
                throw new Exception("Hatalı istek oluturuldu");
            }

            var resultModel = _mapper.Map<InstallmentModel>(result.InstallmentDetails[0]);

            return resultModel;
        }

        public PaymentResponseModel Pay(PaymentModel model)
        {
            var request = this.InitialPayPaymentRequest(model);
            var payment = Iyzipay.Model.Payment.Create(request, _options);
            return _mapper.Map<PaymentResponseModel>(payment);

        }

        private CreatePaymentRequest InitialPayPaymentRequest(PaymentModel model)
        {
            var checkInstallmentsResult = this.CheckInstallments(model.CardModel.CardNumber, model.Price);

            var paid = checkInstallmentsResult.InstallmentPrices
                .FirstOrDefault(x => x.InstallmentNumber == model.Installment, new InstallmentPriceModel()
                {
                    TotalPrice = model.Price.ToString(new CultureInfo("en-us")),
                    InstallmentNumber = 1,
                    Price = model.Price.ToString(new CultureInfo("en-us"))
                });

            var paymentRequest = new CreatePaymentRequest
            {
                Installment = model.Installment,
                Locale = Locale.TR.ToString(),
                ConversationId = GenerateConversationId(),
                Price = model.Price.ToString(new CultureInfo("en-US")),
                PaidPrice = paid.TotalPrice,
                Currency = Currency.TRY.ToString(),
                BasketId = StringHelpers.GenerateUniqueCode(),
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                PaymentCard = _mapper.Map<PaymentCard>(model.CardModel),
                Buyer = _mapper.Map<Buyer>(model.Customer),
                BillingAddress = _mapper.Map<Address>(model.Address),
                ShippingAddress = _mapper.Map<Address>(model.Address)
            };
            var basketItems = new List<BasketItem>();

            foreach (var basketModel in model.BasketList)
            {
                basketItems.Add(_mapper.Map<BasketItem>(basketModel));
            }
            paymentRequest.BasketItems = basketItems;

            return paymentRequest;
        }
    }
}
