using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rabota
{
    public class ReturnAct
    {
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public ReturnAct(DateTime date, string productName, int quantity, string reason)
        {
            Date = date;
            ProductName = productName;
            Quantity = quantity;
            Reason = reason;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ReturnAct))
                return false;
            else
                return this.Date == ((ReturnAct)obj).Date && this.ProductName == ((ReturnAct)obj).ProductName && this.Quantity == ((ReturnAct)obj).Quantity && this.Reason == ((ReturnAct)obj).Reason;
        }
        public string PrintInfo() => $"Дата возврата: {Date.ToShortDateString()}\nТовар: {ProductName}\nКоличество: {Quantity}\nПричина: {Reason}\n";
    }
}
