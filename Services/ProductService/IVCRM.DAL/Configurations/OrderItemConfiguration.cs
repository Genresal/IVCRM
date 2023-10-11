using IVCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IVCRM.DAL.Configurations;

public class OrderItemConfiguration : EntityConfiguration<OrderItem>
{
    public override void AppendConfiguration(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.OrderItems)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");
    }
}
