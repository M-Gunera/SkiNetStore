using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(order => order.ShipToAddress, order =>
            {
                order.WithOwner();
                order.Property(o => o.FirstName).IsRequired();
                order.Property(o => o.LastName).IsRequired();
                order.Property(o => o.Street).IsRequired();
                order.Property(o => o.City).IsRequired();
                order.Property(o => o.ZipCode).IsRequired();
            });

            builder.Property(order => order.Status).HasConversion(
                o => o.ToString(),
                o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
            );

            builder.HasMany(order => order.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}