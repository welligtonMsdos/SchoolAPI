using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Mappings;

public class GradesMap : IEntityTypeConfiguration<Grades>
{
    public void Configure(EntityTypeBuilder<Grades> builder)
    {
        builder.ToTable("Grade");

        builder.Property(p => p.Grades1)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

        builder.Property(p => p.Grades2)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

        builder.Property(p => p.Grades3)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

        builder.Property(p => p.Grades4)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

        builder.HasOne(p => p.Students)
            .WithMany(p => p.Grades)
            .HasForeignKey(p => p.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Matters)
            .WithMany(p => p.Grades)
            .HasForeignKey(p => p.MatterId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
