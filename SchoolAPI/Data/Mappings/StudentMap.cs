using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Mappings;

public class StudentMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student");

        builder.Property(p => p.Name)
                .HasColumnType("varchar(8)")
                .IsRequired();

        builder.Property(p => p.Active)
                .HasColumnType("bit")
                .IsRequired();

        builder.Property(p => p.Ra)
               .HasColumnType("varchar(7)")
               .IsRequired();

        builder.Property(p => p.Password)
               .HasColumnType("varchar(max)")
               .IsRequired();

        builder.Property(p => p.ConfirmPassword)
               .HasColumnType("varchar(max)")
               .IsRequired();

        builder.HasOne(p => p.Address)
             .WithMany(p => p.Students)
             .HasForeignKey(p => p.AddressId)
             .OnDelete(DeleteBehavior.NoAction);
    }
}
