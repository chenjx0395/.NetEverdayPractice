using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.practice
{
    internal class Program
    {
        public static void main()
        {
            var bankAccount = new BankAccount("cxk", 1000);
            Console.WriteLine($"银行账号创建成功！账号ID：{bankAccount.Id} 账号名：{bankAccount.Owner} 初始金额：{bankAccount.Balance}");
            // 测试存取款功能是否正常
            bankAccount.MakeDeposit(100, DateTime.Now, "发工资");
            Console.WriteLine(bankAccount.Balance);
            bankAccount.MakeWithDrawal(500, DateTime.Now, "买鞋");
            Console.WriteLine(bankAccount.Balance);

            // 测试创建异常
            try
            {
                var abnormalAccount = new BankAccount("error", -100);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
            }

            // 测试取款金额不足
            try
            {
                bankAccount.MakeWithDrawal(1500, DateTime.Now, "吃豪华大餐");
                // 出现异常后此行代码不执行
                Console.WriteLine("@@@@@@@@@@@@@@@@@@"+bankAccount.Balance);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
