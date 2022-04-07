namespace Mvc101.Models;

public class MailModel
{
    public List<EmailModel> To { get; set; }
    public List<EmailModel> Cc { get; set; }
    public List<EmailModel> Bcc { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<Stream> Attachs { get; set; }
}