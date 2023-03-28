namespace SchoolAPI.Data.Dto.Address;

public class ReadAddressDto
{
    public int Id { get; set; }   
    public string Cep { get; set; }    
    public string Street { get; set; }   
    public string Number { get; set; }   
    public string Neighborhood { get; set; }    
    public string City { get; set; }   
    public string Uf { get; set; }
}
