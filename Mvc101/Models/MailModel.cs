namespace Mvc101.Models;

public class MailModel
{
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<Stream> Attachs { get; set; }
}