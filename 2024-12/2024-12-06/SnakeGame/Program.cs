namespace SnakeGame
{
    internal static class Program
    {
        //hello
        /// <summary>
        ///应用程序的主要入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}