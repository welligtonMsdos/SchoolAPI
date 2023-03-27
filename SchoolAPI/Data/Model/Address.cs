using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.Data.Model;

public class Address
{
    public Address(int id, string cep, string street, string number, string neighborhood, string city, string uf)
    {
        Id = id;
        Cep = cep;
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        Uf = uf;
    }

    [Key]   
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "CEP", Prompt = "Enter the CEP")]
    [StringLength(8, ErrorMessage = "Must be 8 characters", MinimumLength = 8)]
    public string Cep { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "Street", Prompt = "Enter the street")]
    [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
    public string Street { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "Number", Prompt = "Enter the number")]
    public string Number { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "neighborhood", Prompt = "Enter o neighborhood")]
    [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
    public string Neighborhood { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "Cidade", Prompt = "Enter the city")]
    [MinLength(5, ErrorMessage = "City must 5 characters")]
    public string City { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Display(Name = "UF", Prompt = "UF")]
    [MinLength(2, ErrorMessage = "Enter the UF")]
    [MaxLength(2)]
    [RegularExpression(@"[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$", ErrorMessage = "Use only alphabetic characters")]
    public string Uf { get; set; }

    public ICollection<Student> Students { get; set; }
}
