using System;

namespace _3_委托练习_字符串处理
{
    public delegate string StringHandle(string str);
    internal class Program
    {
        public static void Main(string[] args)
        {
            //将一个字符串数组中的每个元素，分别进行转大写、小写、加双引号的处理
            string[] strs =  { "heLLo", "woRld", "C#.Net" };
            // StringManipulation(strs,str=>str.ToUpper());
            StringManipulation(strs,str=>str.ToLower());
            StringManipulation(strs,str=>"\""+str+"\"");
            foreach (var str in strs)
            {
                Console.WriteLine(str);
            }
            
        }
        
        public static void StringManipulation(string[] strs,StringHandle stringHandle)
        {
            for (var i = 0; i < strs.Length; i++)
            {
                // 委托处理
                strs[i] =  stringHandle(strs[i]);
            }
        }
    }
}