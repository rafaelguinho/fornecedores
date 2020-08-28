using System;

namespace Domain.Models.Abstract.Person
{
    public abstract class NaturalPerson
    {
        public DateTime BirthDate { get; set; }

        public string NationalIdentityCard { get; set; }

        public string CPF { get; set; }
    }
}
