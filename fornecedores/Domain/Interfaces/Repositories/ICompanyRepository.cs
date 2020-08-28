using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ICompanyRepository : IQuery<Company>, ICommand<Company>
    {
    }
}
