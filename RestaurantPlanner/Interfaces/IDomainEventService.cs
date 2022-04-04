using RestaurantPlanner.Common;

namespace RestaurantPlanner.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}