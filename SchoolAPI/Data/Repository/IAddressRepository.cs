using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Repository;

public interface IAddressRepository : IQuery<Address>, ICommand<Address>
{
}
