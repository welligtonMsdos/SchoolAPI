using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Mappings;

public class AddressMap : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");

        builder.Property(p => p.Cep)
                .HasColumnType("varchar(8)")
                .IsRequired();

        builder.Property(p => p.Street)
               .HasColumnType("varchar(50)")
               .IsRequired();

        builder.Property(p => p.Number)
               .HasColumnType("varchar(10)")
               .IsRequired();

        builder.Property(p => p.Neighborhood)
               .HasColumnType("varchar(50)")
               .IsRequired();

        builder.Property(p => p.City)
               .HasColumnType("varchar(50)")
               .IsRequired();

        builder.Property(p => p.Uf)
               .HasColumnType("varchar(2)")
               .IsRequired();
    }
}
