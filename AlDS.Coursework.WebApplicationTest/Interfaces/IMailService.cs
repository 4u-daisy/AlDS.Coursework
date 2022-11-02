using AlDS.Coursework.WebApplicationTest.Models;
using System.Threading.Tasks;

namespace AlDS.Coursework.WebApplicationTest.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
