using Domain.Dtos;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        bool Add(NewCompanyDto company);

        IEnumerable<CompanyListDto> ListAll();
        
    }
}
