using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talabat.Core.Entities.Order;

namespace Talabat.Repository.Data.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Status)
                .HasConversion(OS => OS.ToString(), os => (OrderStatus)Enum.Parse(typeof(OrderStatus), os));

            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");

            builder.OwnsOne(o => o.ShoppingAddress, SA => SA.WithOwner());

            builder.HasOne(o => o.DeliveryMethod).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
