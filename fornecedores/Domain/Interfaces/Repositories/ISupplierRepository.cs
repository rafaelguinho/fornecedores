using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ISupplierRepository : IQuery<NaturalPersonSupplier>, IQuery<LegalPersonSupplier>, ICommand<NaturalPersonSupplier>, ICommand<LegalPersonSupplier>
    {
    }
}
