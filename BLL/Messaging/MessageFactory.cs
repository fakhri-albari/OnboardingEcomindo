using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingEcomindo.BLL.Messaging
{
    public class MessageFactory
    {
        public MessageSender Create(IConfiguration config, string topic)
        {
            return new MessageSender(config, topic);
        }
    }
}
