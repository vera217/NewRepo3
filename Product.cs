using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rabota
{
    public class Product
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product(DateTime date, string name, int quantity)
        {
            Date = date;
            Name = name;
            Quantity = quantity;

        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Product))
                return false;
            else
                return this.Date == ((Product)obj).Date && this.Name == ((Product)obj).Name && this.Date == ((Product)obj).Date;
        }
        public virtual string PrintInfo()
        {
            return $"Дата: {Date.ToShortDateString()} \nНазвание: {Name} \nКоличество: {Quantity} \n";
        }
    }
}
