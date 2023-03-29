using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Data.Dto.Student;

public class PostUpdateStudentDto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
    [Display(Name = "Name", Prompt = "Enter the name")]
    public string Name { get; set; }

    public bool Active { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(7, ErrorMessage = "Must be 7 characters", MinimumLength = 7)]
    [Display(Name = "RA", Prompt = "Enter the RA")]
    public string Ra { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [Display(Name = "password", Prompt = "Enter the password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [Display(Name = "RA", Prompt = "Enter the password")]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required]
    public int AddressId { get; set; }
}
