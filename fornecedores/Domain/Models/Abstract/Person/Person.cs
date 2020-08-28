using Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Models.Abstract.Person
{
    public abstract class Person : BaseModel
    {
        public string Name { get; set; }

        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        public ICollection<Phone> Phones { get; set; }

        public abstract PersonType PersonType { get; }
    }
}
