using System;

namespace _1_委托案例
{
    // 定义委托
    public delegate void OutputTimeDelegate(DateTime dateTime);
    
    public static class TimeTool
    {
        public static void OutputTime(OutputTimeDelegate outputTimeDelegate)
        {
            // 1. 模拟公共逻辑
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine("公共逻辑执行中！！！");
            }
            // 2. 调用委托实现差异化的日期输出
            var dateTime = DateTime.Now;
            outputTimeDelegate(dateTime);
        }
    }
}