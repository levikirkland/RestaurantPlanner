using MediatR;
using System.Text.Json;
using RestaurantPlanner.Common;
using RestaurantPlanner.Events;

namespace RestaurantPlanner.Handlers
{
    public class CreatedNewAccountEventHandler : INotificationHandler<DomainEventNotification<CreatedNewAccountEvent>>
    {
        private readonly ILogger<CreatedNewAccountEventHandler> _logger;

        public CreatedNewAccountEventHandler(ILogger<CreatedNewAccountEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<CreatedNewAccountEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification;
            var jsonString = JsonSerializer.Serialize(notification.DomainEvent.accountInfo);
            _logger.LogInformation("Restaurant Planner Event: {DomainEvent} accountInfo {jsonString}", domainEvent.GetType().Name, jsonString);

            //rmq  or repo call to create new user based on account info

            return Task.CompletedTask;
        }
    }
}
