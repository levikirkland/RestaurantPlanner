using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RestaurantPlanner.Data;
using RestaurantPlanner.Models;

namespace RestaurantPlanner.Validation
{
    public class AccountInfoValidator : AbstractValidator<AccountInfo>
    {
        private readonly ApplicationDbContext _context;

        public AccountInfoValidator(ApplicationDbContext context)
        {
            RuleFor(p => p.FirstName).NotEmpty().NotNull();
            RuleFor(p => p.LastName).NotEmpty().NotNull();
            RuleFor(p => p.Address1).NotEmpty().NotNull();
            RuleFor(p => p.EmailAddress).NotEmpty().EmailAddress().WithMessage("We suggest only using a company email address here.")
                .MustAsync(BeUniqueEmailAddress).WithMessage("Email Address is already in use.");
            RuleFor(p => p.City).NotEmpty().WithMessage("Valid City within your State is necessary.");
            RuleFor(p => p.State).NotNull().NotEmpty().WithMessage("Please select State");
            RuleFor(p => p.Zipcode).NotEmpty().WithMessage("Please add zip code.");
            _context = context;
        }

        public async Task<bool> BeUniqueEmailAddress(AccountInfo accountInfo, string EmailAddress, CancellationToken cancellationToken)
        {
            return await _context.Accounts.Where(l => l.Id == accountInfo.Id).AnyAsync(l => l.EmailAddress == EmailAddress);
        }

    }

   
}
