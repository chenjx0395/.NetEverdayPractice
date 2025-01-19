using System.IO;
using System.Text;

namespace _01_打印日志到文件_V1
{
    /// <summary>
    /// 将日志写入文件
    /// </summary>
    public class Logger
    {
        private  const string FileName = "log.txt";
        // private readonly object o = new object();
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="log"></param>
        public void WriteLog(string log)
        {
            using (FileStream fs = new FileStream(FileName,FileMode.Append))
            {
                var bytes = Encoding.UTF8.GetBytes(log+"\n");
                // lock (o) 对象锁解决不了问题，需要类锁
                lock (typeof(Logger))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }

    }
}