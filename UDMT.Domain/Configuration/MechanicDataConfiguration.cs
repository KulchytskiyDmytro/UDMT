using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UDMT.Domain.Entity.Classes;

namespace UDMT.Domain.Configuration;

public class MechanicDataConfiguration : IEntityTypeConfiguration<ClassMechanic>
{
    public void Configure(EntityTypeBuilder<ClassMechanic> builder)
    {
        builder.OwnsOne(m => m.Data, data =>
        {
            data.OwnsOne(d => d.BonusDamage); // 👈 Це обов’язково
        });
    }
}