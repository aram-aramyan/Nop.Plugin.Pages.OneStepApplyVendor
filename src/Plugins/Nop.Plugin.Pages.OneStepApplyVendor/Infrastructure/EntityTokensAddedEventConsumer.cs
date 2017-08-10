using Nop.Core.Domain.Messages;
using Nop.Core.Domain.Vendors;
using Nop.Services.Events;
using Nop.Services.Messages;

namespace Nop.Plugin.Pages.OneStepApplyVendor.Infrastructure
{
    public class EntityTokensAddedEventConsumer : IConsumer<EntityTokensAddedEvent<Vendor, Token>>
    {
        public void HandleEvent(EntityTokensAddedEvent<Vendor, Token> eventMessage)
        {
            eventMessage.Tokens.Add(new Token("Vendor.Description", eventMessage.Entity.Description, true));
        }
    }
}
