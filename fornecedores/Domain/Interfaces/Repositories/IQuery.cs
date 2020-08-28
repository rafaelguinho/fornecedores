using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IQuery<T>
    {
        IEnumerable<T> ListAll();

        T GetById(int id);
    }
}
