using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Mappings;

public class MatterProfessorMap : IEntityTypeConfiguration<MatterProfessor>
{
    public void Configure(EntityTypeBuilder<MatterProfessor> builder)
    {
        builder.ToTable("MatterProfessor");

        builder.HasOne(p => p.Matter)
             .WithMany(p => p.matterProfessors)
             .HasForeignKey(p => p.MatterId)
             .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Professor)
             .WithMany(p => p.matterProfessors)
             .HasForeignKey(p => p.ProfessorId)
             .OnDelete(DeleteBehavior.NoAction);
    }
}
