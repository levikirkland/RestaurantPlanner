using RestaurantPlanner.Common.Enums;
using RestaurantPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantPlanner.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData
                (new Location
                {
                    Id = 2121,
                    AccountInfoId = 1,
                    ContactFirstName = "James",
                    ContactLastName = "Smith",
                    EmailAddress = "Mail@3Cousins.net",
                    LocationName = "3 Cousins Diner",
                    Phone = "2258989",
                    Address1 = "111 Main Street",
                    Address2 = null,
                    City = "Monarch",
                    State = States.GA,
                    Zipcode = "31792",
                    CreatedBy = "superadmin",
                    ModifiedBy = "superadmin",
                });

            builder.Ignore(p => p.DomainEvents);
            builder.Property(p => p.ContactFirstName).IsRequired()
                .HasColumnType("varchar").HasMaxLength(15);
            builder.Property(p => p.ContactLastName).IsRequired()
                .HasColumnType("varchar").HasMaxLength(15);
            builder.Property(p => p.LocationName).IsRequired()
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
