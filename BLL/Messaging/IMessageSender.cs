using System;
using System.Threading.Tasks;

namespace OnboardingEcomindo.BLL.Messaging
{
    public interface IMessageSender
    {
        Task CreateEventBatchAsync();
        bool AddMessage(object data);
        Task SendMessage();
    }
}
