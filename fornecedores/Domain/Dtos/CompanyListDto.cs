using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class CompanyListDto : BaseDto
    {
        public string FederativeUnit { get; set; }

        public string CNPJ { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        public ICollection<PhoneDto> Phones { get; set; }
    }
}
