using Store.Common.Helpers;

namespace Store.Backend.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string body);
    }
}
