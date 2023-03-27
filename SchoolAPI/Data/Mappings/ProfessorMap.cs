using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Mappings;

public class ProfessorMap : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.ToTable("Professor");

        builder.Property(p => p.Name)
                .HasColumnType("varchar(8)")
                .IsRequired();

        builder.Property(p => p.Active)
                .HasColumnType("bit")
                .IsRequired();
    }
}
