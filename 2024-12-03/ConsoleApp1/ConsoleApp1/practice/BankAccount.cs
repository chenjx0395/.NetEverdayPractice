using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.practice
{
    public class BankAccount
    {
        private static int s_accountNumberSeed = 100000000;
        public string Id { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransaction)
                    balance += item.Amount;
                return balance;
            }
        }
        private List<Transaction> allTransaction  = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            Owner = name;
            // 创建id
            Id = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;
            // 创建初始金额交易记录
            MakeDeposit(initialBalance, DateTime.Now, "初始增加金额");
        }

        public void MakeDeposit(decimal amount, DateTime dateTime, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "存款金额为负数");
            }
            var deposit = new Transaction(amount, dateTime, note);
            allTransaction.Add(deposit);
        }

        public void MakeWithDrawal(decimal amount, DateTime dateTime, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "取款金额为负数");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("取款金额高于存款");
            }
            var deposit = new Transaction(-amount, dateTime, note);
            allTransaction.Add(deposit);
        }

    }
}
