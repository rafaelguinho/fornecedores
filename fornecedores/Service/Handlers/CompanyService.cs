using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Validation;
using System;
using System.Collections.Generic;

namespace Service.Handlers
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IValidationDictionary validation;

        public CompanyService(ICompanyRepository companyRepository, IValidationDictionary validation)
        {
            this.companyRepository = companyRepository;
            this.validation = validation;
        }

        public bool Add(NewCompanyDto company)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyListDto> ListAll()
        {
            throw new NotImplementedException();
        }
    }
}
