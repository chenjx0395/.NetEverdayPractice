using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_抽象工厂设计模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        //抽象的产品类型
        interface IMouse
        {
            /// <summary>
            /// 展示鼠标品牌
            /// </summary>
            void ShowMouseBrand();
        }
        interface IBrand
        {
            /// <summary>
            /// 展示键盘品牌
            /// </summary>
            void ShowMouseBrand();
    }


    }
}
