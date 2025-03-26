using FluentValidation;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Validation
{
    public class AccountInfoValidator : AbstractValidator<Account>
    {
        private readonly IAccountInfoRepository _repo;

        public AccountInfoValidator(IAccountInfoRepository repo)
        {
            RuleFor(p => p.FirstName).NotEmpty().NotNull();
            RuleFor(p => p.LastName).NotEmpty().NotNull();
            RuleFor(p => p.Address1).NotEmpty().NotNull();
            RuleFor(p => p.EmailAddress).NotEmpty().EmailAddress().WithMessage("We suggest only using a company email address here.")
                .MustAsync(BeUniqueEmailAddress).WithMessage("Email Address is already in use.");
            RuleFor(p => p.City).NotEmpty().WithMessage("Valid City within your State is necessary.");
            RuleFor(p => p.State).NotNull().NotEmpty().WithMessage("Please select State");
            RuleFor(p => p.Zipcode).NotEmpty().WithMessage("Please add zip code.");
            _repo = repo;
        }

        public async Task<bool> BeUniqueEmailAddress(Account accountInfo, string EmailAddress, CancellationToken cancellationToken)
        {
            var acctInfo = await _repo.IsUniqueByAccountAndEmailAddress(EmailAddress, accountInfo.Id);
            if (accountInfo == null)
            {
                return false;
            }
            return true;
        }
    }
}
