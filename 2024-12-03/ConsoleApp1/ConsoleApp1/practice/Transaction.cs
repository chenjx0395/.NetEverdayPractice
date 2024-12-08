using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.practice
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime DateTime { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime dateTime,string note)
        {
            Amount = amount;
            DateTime = dateTime;
            Notes = note;
        }
    }
}
