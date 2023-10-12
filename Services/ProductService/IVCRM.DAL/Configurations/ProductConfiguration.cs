using IVCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IVCRM.DAL.Configurations;

public class ProductConfiguration : EntityConfiguration<Product>
{
    public override void AppendConfiguration(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
    }
}
