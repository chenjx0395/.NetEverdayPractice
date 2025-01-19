using System.IO;
using System.Text;

namespace _02_打印日志到文件_V2
{
    /// <summary>
    /// 将日志写入文件
    /// </summary>
    public class Logger
    {
        private  const string FileName = "log.txt";
        private static readonly Logger _instance = new Logger();
        private Logger()
        {

        }

        public static Logger Instance()
        {
            
                return _instance;
        }
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="log"></param>
        public void WriteLog(string log)
        {
            using (FileStream fs = new FileStream(FileName,FileMode.Append))
            {
                var bytes = Encoding.UTF8.GetBytes(log+"\n");
                fs.Write(bytes,0,bytes.Length);
            }
        }

    }
}