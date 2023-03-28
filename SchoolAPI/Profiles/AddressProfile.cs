using AutoMapper;
using SchoolAPI.Data.Dto.Address;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Profiles;

public class AddressProfile: Profile
{
    public AddressProfile()
    {
        CreateMap<ReadAddressDto, Address>().ReverseMap();
    }
}
