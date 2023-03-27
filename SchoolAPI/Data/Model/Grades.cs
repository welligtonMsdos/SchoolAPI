using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Data.Model;

public class Grades
{
    public Grades(int id, float grades1, float grades2, float grades3, float grades4, int studentId, int matterId)
    {
        Id = id;
        Grades1 = grades1;
        Grades2 = grades2;
        Grades3 = grades3;
        Grades4 = grades4;
        StudentId = studentId;        
        MatterId = matterId;
    }

    [Key]
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
    public Student Students { get; set; }

    [Required]
    public int MatterId { get; set; }
    public Matter Matters { get; set; }
}
