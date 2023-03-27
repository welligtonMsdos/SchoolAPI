using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Mappings;

public class MatterMap : IEntityTypeConfiguration<Matter>
{
    public void Configure(EntityTypeBuilder<Matter> builder)
    {
        builder.ToTable("Matter");

        builder.Property(p => p.Name)
                .HasColumnType("varchar(50)")
                .IsRequired();

        builder.Property(p => p.Active)
                .HasColumnType("bit")
                .IsRequired();
    }
}
