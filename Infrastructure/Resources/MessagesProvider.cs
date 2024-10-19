using System.Resources;
using Raffle.Domain.IResources;

namespace Raffle.Infrastructure.Resources
{
    public class MessagesProvider : IMessagesProvider
    {
        private readonly ResourceManager resourceManager;

        public MessagesProvider()
        {
            resourceManager = new ResourceManager("Raffle.Infrastructure.Resources.Messages", typeof(MessagesProvider).Assembly);
        }
    }
}
