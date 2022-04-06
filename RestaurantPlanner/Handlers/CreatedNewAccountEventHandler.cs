using MediatR;
using System.Text.Json;
using RestaurantPlanner.Common;
using RestaurantPlanner.Events;
using RestaurantPlanner.Models;
using Microsoft.AspNetCore.Identity;

namespace RestaurantPlanner.Handlers
{
    public class CreatedNewAccountEventHandler : INotificationHandler<DomainEventNotification<CreatedNewAccountEvent>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CreatedNewAccountEventHandler> _logger;

        public CreatedNewAccountEventHandler(UserManager<ApplicationUser> userManager,ILogger<CreatedNewAccountEventHandler> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<CreatedNewAccountEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification;
            var jsonString = JsonSerializer.Serialize(notification.DomainEvent.accountInfo);
            _logger.LogInformation("Restaurant Planner Event: {DomainEvent} accountInfo {jsonString}", domainEvent.GetType().Name, jsonString);

            return Task.CompletedTask;
        }
    }
}
