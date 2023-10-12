using IVCRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IVCRM.DAL.Configurations;

public class StorageConfiguration : EntityConfiguration<Storage>
{
    public override void AppendConfiguration(EntityTypeBuilder<Storage> builder)
    {
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Storages)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
