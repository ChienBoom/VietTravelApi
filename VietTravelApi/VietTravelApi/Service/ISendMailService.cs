using System.Threading.Tasks;
using VietTravelApi.Models;

namespace VietTravelApi.Service
{
    public interface ISendMailService
    {
        Task SendMail(MailContent mailContent);

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
