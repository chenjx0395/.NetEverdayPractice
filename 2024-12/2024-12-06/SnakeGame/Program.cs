namespace SnakeGame
{
    internal static class Program
    {
        //hello
        /// <summary>
        ///Ӧ�ó������Ҫ��ڵ㡣
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}