using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Mappings;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.EFCore;

public class SchoolContext: DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) {}

    public DbSet<Address> Address { get; set; }
    public DbSet<Grades> Grades { get; set; }
    public DbSet<Matter> Matters { get; set; }
    public DbSet<MatterProfessor> MatterProfessors { get; set; }
    public DbSet<Professor> professors { get; set; }
    public DbSet<Student> Students { get; set; }      

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressMap());
        modelBuilder.ApplyConfiguration(new GradesMap());
        modelBuilder.ApplyConfiguration(new MatterMap());
        modelBuilder.ApplyConfiguration(new MatterProfessorMap());
        modelBuilder.ApplyConfiguration(new ProfessorMap());
        modelBuilder.ApplyConfiguration(new StudentMap());
    }
}
