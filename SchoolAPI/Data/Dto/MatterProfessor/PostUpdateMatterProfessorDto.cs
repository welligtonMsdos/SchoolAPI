using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Data.Dto.MatterProfessor;

public class PostUpdateMatterProfessorDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public int MatterId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public int ProfessorId { get; set; }
}
