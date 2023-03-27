using SchoolAPI.Data.Interface;
using SchoolAPI.Data.Model;

namespace SchoolAPI.Data.Repository;

public interface IMatterRepository : IQuery<Matter>, ICommand<Matter>
{
}
