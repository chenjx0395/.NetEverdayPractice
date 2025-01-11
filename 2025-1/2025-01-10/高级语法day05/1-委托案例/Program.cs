namespace _1_委托案例
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var consoleTime = new ConsoleTime();
            var dbTime = new DBTime();
            var fileTime = new FileTime();
            TimeTool.OutputTime(consoleTime.OutputTime);
            TimeTool.OutputTime(dbTime.OutputTime);
            TimeTool.OutputTime(fileTime.OutputTime);
        }
    }
}