// 根据 https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/tutorials/classes 创建的“类”相关案例
using ConsoleApp1.Classes;
using ConsoleApp1.practice;
using BankAccount = ConsoleApp1.Classes.BankAccount;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void Main()
        {
            //联系测试
            practice.Program.main();
            //参考测试
            //referenceTesting();
        }

        // 参考测试
        public static void referenceTesting()
        {
            var account = new BankAccount("chenjx", 1000);
            Console.WriteLine($"账号 {account.Number} 创建了！账号名：{account.Owner} 。 第一次存入金额：{account.Balance}");

            // 测试添加，取款功能是否正常
            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            // 测试错误创建账号是否可以正常抛出异常
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("创建初始金额为负数时发生异常");
                Console.WriteLine(e.ToString());
                //return;
            }
            // 测试错误存取款是否可以正常抛出异常
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("余额不足");
                Console.WriteLine(e.ToString());
            }
        }
    }
}






