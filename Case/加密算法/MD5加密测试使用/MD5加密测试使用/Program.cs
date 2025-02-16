using System.Security.Cryptography;
using System.Text;

namespace MD5加密测试使用
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 创建一个MD5对象
            using (MD5 md5 =MD5.Create())
            {
                // 模拟密码
                string password = "admin";
                // 将密码转换为字节数组
                var bytes = Encoding.UTF8.GetBytes(password);
                // 生成了MD5加密后的字节数组,共16个
                byte[] computeHash = md5.ComputeHash(bytes);
                foreach (var hashCode in computeHash)
                {
                    //将byte 转换为16进制字符串打印
                    Console.Write(hashCode.ToString("X2"));
                }
            }
        }
    }
}
