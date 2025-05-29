using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Domain.Common;
using MediatR;

namespace CleanArchitecture.Application.Application.Problems.Events;
public class ProblemsUpdatedEvent(string[] cacheKeys) : BaseEvent
{
    public ProblemsUpdatedEvent() : this([])
    {

    }

    public string[] CacheKeys { get; set; } = cacheKeys ?? [];
};
internal class ProblemsUpdatedEventHandler(IDistributedCache cache) : INotificationHandler<ProblemsUpdatedEvent>
{
    public async Task Handle(ProblemsUpdatedEvent notification, CancellationToken cancellationToken)
    {
        foreach (var cacheKey in notification.CacheKeys)
            await cache.RemoveAsync(cacheKey, cancellationToken);
        await cache.RemoveAsync("problemsList", cancellationToken);
    }
}