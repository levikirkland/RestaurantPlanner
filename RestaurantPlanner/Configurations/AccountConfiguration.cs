using RestaurantPlanner.Common.Enums;
using RestaurantPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantPlanner.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountInfo>
    {
        public void Configure(EntityTypeBuilder<AccountInfo> builder)
        {
            builder.HasData
                (new AccountInfo
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Smith",
                    EmailAddress = "Mail@3Cousins.net",
                    CompanyName = "3 Cousins Diner",
                    Phone = "2258989",
                    Address1 = "111 Main Street",
                    Address2 = null,
                    City = "Monarch",
                    State = States.GA,
                    Zipcode = "31792",
                    CreatedBy = "superadmin",
                    ModifiedBy = "superadmin",
                    AccountType = AccountTypes.Basic,
                    SignUpDate = DateTime.Now,

                });

            builder.Ignore(p => p.DomainEvents);
            builder.Property(p => p.FirstName).IsRequired()
                .HasColumnType("varchar").HasMaxLength(15);
            builder.Property(p => p.LastName).IsRequired()
                .HasColumnType("varchar").HasMaxLength(15);
            builder.Property(p => p.CompanyName).IsRequired()
                .HasColumnType("varchar").HasMaxLength(25);
            builder.Property(p => p.EmailAddress).IsRequired()
                .HasColumnType("varchar").HasMaxLength(45);
            builder.Property(p => p.CreatedBy)
                .HasColumnType("varchar").HasMaxLength(36);
            builder.Property(p => p.ModifiedBy)
                .HasColumnType("varchar").HasMaxLength(36);
            builder.Property(p => p.Phone).IsRequired()
                .HasColumnType("varchar").HasMaxLength(10);
            builder.Property(p => p.Address1).IsRequired()
               .HasColumnType("varchar").HasMaxLength(40);
            builder.Property(p => p.Address2)
                .HasColumnType("varchar").HasMaxLength(40);
            builder.Property(p => p.City).IsRequired()
                .HasColumnType("varchar").HasMaxLength(20);
            builder.Property(p => p.Zipcode).IsRequired()
                .HasColumnType("varchar").HasMaxLength(10);

        }
    }
}
