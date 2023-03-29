using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Data.Dto.Grades;

public class PostUpdateGradesDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "1ª grade", Prompt = "Enter the 1ª grade")]
    public float Grades1 { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "2ª grade", Prompt = "Enter the 2ª grade")]
    public float Grades2 { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "3ª grade", Prompt = "Enter the 3ª grade")]
    public float Grades3 { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "4ª grade", Prompt = "Enter the 4ª grade")]
    public float Grades4 { get; set; }

    [Required]
    public int StudentId { get; set; }  

    [Required]
    public int MatterId { get; set; }   
}
