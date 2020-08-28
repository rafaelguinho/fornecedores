using Domain.Models.Abstract.Person;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Company : LegalPerson
    {
        public string FederativeUnit { get; set; }

        public ICollection<NaturalPersonSupplier> NaturalPersonSuppliers { get; set; }


        public ICollection<LegalPersonSupplier> LegalPersonSuppliers { get; set; }
    }
}
