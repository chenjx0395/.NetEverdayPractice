using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        interface IUser
        {
            void Task();
        }

        class User1 : IUser
        {
            public void Task()
            {
                throw new NotImplementedException();
            }
        }

        static class User
        {
            static IUser getUser1()
            {
                return new User1();
            }
        }
    }
}
