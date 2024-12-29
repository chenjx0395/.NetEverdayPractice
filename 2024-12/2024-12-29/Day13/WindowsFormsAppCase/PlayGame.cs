
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppCase
{
    internal class PlayGame
    {
        private static readonly Random Random = new Random();

        // 引入图片资源
        private static readonly Image[] Images = { Resource1._1, Resource1._2, Resource1._3, Resource1._4, Resource1._5, Resource1.jsb };

        public static Image ComputerActionImage(int userSelect, out byte result)
        {
            var next = Random.Next(2, 5);
            if (next == userSelect)
            {
                result = 0;
                return Images[next];
            }
            if (next > userSelect)
            {
                result = userSelect + 1 == next ? (byte)2 : (byte)1;
            }
            else
            {
                result = next + 1 == userSelect ? (byte)1 : (byte)2;
            }
            return Images[next];
        }


    }
}
