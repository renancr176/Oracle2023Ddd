using MediatR;
using Microsoft.EntityFrameworkCore;
using Rte2023Ddd.Domain.Core.DomainObjects;

namespace Rte2023Ddd.Infra.Data;

public static class MediatorExtension
{
    public static async Task PublishEvent(this IMediator mediator, DbContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.Notifications)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearEvents());

        var tasks = domainEvents
            .Select(async (domainEvent) => {
                await mediator.Publish(domainEvent);
            });

        await Task.WhenAll(tasks);
    }
}