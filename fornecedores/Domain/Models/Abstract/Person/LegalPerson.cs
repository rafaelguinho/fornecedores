using Domain.Models.Enums;

namespace Domain.Models.Abstract.Person
{
    public abstract class LegalPerson : Person
    {
        public string CNPJ { get; set; }

        public override PersonType PersonType { get; } = PersonType.LegalPerson;
    }
}
