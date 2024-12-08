using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
支持的功能：
1.用一个10位数唯一标识银行帐户
2.用字符串存储一个或多个所有者名称
3.可以检索余额
4.接受存款
5.接受取款
6.初始余额必须是正数
7.取款后的余额不能是负数
 */
namespace ConsoleApp1.Classes
{
    public class BankAccount
    {
        //账号初始化种子
        private static int s_accountNumberSeed = 1000000000;
        //银行账号标识
        public string Number  { get; }
        //账号名
        public string Owner { get; set; }
        //存款
        public decimal Balance {
            //每次获取余额都会根据交易记录计算
            get
            {
                decimal balance = 0;
                foreach (var item in _allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            } 
        }

        public BankAccount(string name,decimal initialBalance)
        {
            Number = s_accountNumberSeed.ToString();
            s_accountNumberSeed++;

            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        //交易记录
        private List<Transaction> _allTransactions = new List<Transaction>();

        //存款
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount < 0) { 
                throw new ArgumentOutOfRangeException(nameof(amount),"存款金额必须为正数");
            }
            var deposit = new Transaction(amount, date, note);
            _allTransactions.Add(deposit);
        }
        //提款
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "取款金额必须为正数");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("余额不足");
            }
            var withdrawal = new Transaction(-amount, date, note);
            _allTransactions.Add(withdrawal);
        }
        

    }
}
