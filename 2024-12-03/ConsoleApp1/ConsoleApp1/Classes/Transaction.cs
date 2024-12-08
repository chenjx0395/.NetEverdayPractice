using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 表示交易的类型
 */
namespace ConsoleApp1.Classes
{
    public class Transaction
    {
        //交易金额
        public decimal Amount { get; }
        //交易日期
        public DateTime Date { get; }
        //交易注释
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            Date = date;
            Notes = notes;
        }
    }


}
