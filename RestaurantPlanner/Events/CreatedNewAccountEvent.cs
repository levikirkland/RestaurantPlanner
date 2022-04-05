using RestaurantPlanner.Common;
using RestaurantPlanner.Models;

namespace RestaurantPlanner.Events
{
    public class CreatedNewAccountEvent :DomainEvent
    {
        public AccountInfo accountInfo { get; }
        public List<DomainEvent> DomainEvents { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        
        public CreatedNewAccountEvent(AccountInfo accountInfo)
        {
            this.accountInfo = accountInfo;
        }
    }
}
