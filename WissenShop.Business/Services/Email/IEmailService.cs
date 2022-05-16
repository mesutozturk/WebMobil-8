using WissenShop.Core.Emails;

namespace WissenShop.Business.Services.Email;

public interface IEmailService
{
    Task SendMailAsync(MailModel model);
}