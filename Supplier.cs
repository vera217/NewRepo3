using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rabota
{
    public class Supplier
    {
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }

        public Supplier(string name, string contactPerson, string phoneNumber)
        {
            Name = name;
            ContactPerson = contactPerson;
            PhoneNumber = phoneNumber;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Supplier))
                return false;
            else
                return this.Name == ((Supplier)obj).Name && this.ContactPerson == ((Supplier)obj).ContactPerson && this.PhoneNumber == ((Supplier)obj).PhoneNumber;
        }
        public string PrintInfo() => $"Поставщик: {Name}\nКонтактное лицо: {ContactPerson}\nТелефон: {PhoneNumber}\n";
    }
}

