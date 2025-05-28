using Microsoft.Extensions.Caching.Distributed;
using CleanArchitecture.Domain.Common;
using MediatR;

namespace CleanArchitecture.Application.Application.Problems.Events;
public class ProblemsUpdatedEvent : BaseEvent;
internal class ProblemsUpdatedEventHandler(IDistributedCache cache) : INotificationHandler<ProblemsUpdatedEvent>
{
    public async Task Handle(ProblemsUpdatedEvent notification, CancellationToken cancellationToken)
    {
        await cache.RefreshAsync("problemsList");
    }
}