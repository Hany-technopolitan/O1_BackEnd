
using Techno_Project.Models;

namespace Techno_Project.Repos
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
