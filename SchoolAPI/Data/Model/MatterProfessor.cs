using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Data.Model;

public class MatterProfessor
{
    public MatterProfessor(int id, int matterId, int professorId) => (Id,MatterId,ProfessorId) = (id,matterId,professorId);
    
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public int MatterId { get; set; }

    public Matter Matter { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public int ProfessorId { get; set; }

    public Professor Professor { get; set; }
}
