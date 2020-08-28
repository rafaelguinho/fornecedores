using Domain.Dtos;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface ISupplierService
    {
        bool Add(NewSupplierDto company);

        IEnumerable<SupplierListDto> ListSuppliersByCompany(string companyId);
    }
}
