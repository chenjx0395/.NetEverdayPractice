using System;
using System.IO;
using System.Net;
using System.Text;

namespace Exercise
{
    internal class Program
    {
        private const string OncePath = "D:\\hello.txt";

        public static void Main(string[] args)
        {
            // File 类文件相关API的使用
            // Case1();
            // File 类 `ReadLines(string path)`示例
            // Case2();
            // File 类 `ReadLines(string path, Encoding encoding)`示例
            // Case3();
            // File 类 `static string[] ReadAllLines(string path)`示例
            // Case4();
            // File 类 `ReadAllText(string path)`示例
            //Case5();
            // File 类 `static byte[] ReadAllBytes(string path)`示例
            // Case6();
            // File 类写数据相关方法
            // Case7();
            // File 练习：复制粘贴
            // Case8();
            // Directory 类目录相关API的使用
            // Case9();
            // Directory 练习
            // Case10();
            // Path API使用
            // Case11();
            // path 练习
            // Case12();
            // ReadByte 读取文件
            // Case13();
            // WriteByte 写入文件
            // Case14();
            // using(){} 自动释放资源
            // Case15();
            // Read 读取文件
            // Case16();
            // Write 写入文件
            Case17();
            
            
        }

        public static void Case17()
        {
            const string path = "D:\\test.txt";
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                const string content = "我是你爹";
                var bytes = Encoding.UTF8.GetBytes(content);
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        public static void Case16()
        {
            const string path = "D:\\test.txt";
            var buffer = new byte[1024];
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                while (fs.Read(buffer, 0, buffer.Length) > 0)
                {
                    foreach (var b in buffer)
                    {
                        Console.Write((char)b);
                    }
                }
            }
        }

        public static void Case15()
        {
            const string path = "D:\\test.txt";
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                fs.WriteByte(88);
            }
        }

        public static void Case14()
        {
            const string path = "D:\\test.txt";
            var fileStream = new FileStream(path, FileMode.OpenOrCreate);
            fileStream.WriteByte(111);
        }

        public static void Case13()
        {
            const string path = "D:\\test.txt";
            var fileStream = new FileStream(path, FileMode.OpenOrCreate);
            var bytes = new byte[1024];
            var count = 0;
            while (true)
            {
                var b = fileStream.ReadByte();
                if (b == -1)
                {
                    break;
                }

                bytes[count++] = (byte)b;
            }

            var s = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(s);
            fileStream.Close();
        }

        public static void Case12()
        {
            var path = @"D:\day11\demo\test";
            var suffixes = new[] { "txt", "md", "png" };
            var combines = new string[3];
            var pathNames = new[] { "study", "doc", "test" };
            // 创建文件夹
            Directory.CreateDirectory(path);
            // 创建多个文件
            for (var j = 0; j < 3; j++)
            {
                for (var i = 1; i < 4; i++)
                {
                    var fullPathName = pathNames[j] + i + "." + suffixes[j];

                    var fileStream = File.Create(path + "\\" + fullPathName);
                    fileStream.Close();
                }
            }

            // 创建分类子文件夹
            for (int i = 0; i < 3; i++)
            {
                var combine = Path.Combine(path, suffixes[i]);
                Directory.CreateDirectory(combine);
            }

            // 将test文件夹中的文件归纳到指定子文件夹中
            // 获取所有文件数组，根据文件名拼接路径获取文件后缀
            var filePaths = Directory.GetFiles(path);
            foreach (var filePath in filePaths)
            {
                var fileExtension = Path.GetExtension(filePath);
                var fileName = Path.GetFileName(filePath);
                switch (fileExtension)
                {
                    case ".txt":
                        File.Move(filePath, path + "\\" + suffixes[0] + "\\" + fileName);
                        break;
                    case ".md":
                        File.Move(filePath, path + "\\" + suffixes[1] + "\\" + fileName);
                        break;
                    case ".png":
                        File.Move(filePath, path + "\\" + suffixes[2] + "\\" + fileName);
                        break;
                }
            }
        }

        public static void Case11()
        {
            var path1 = "D:\\Drivers\\Audio\\3rd party\\Dolby";
            var path2 = "D:\\测试.txt";
            // 获得路径参数的所处的路径
            var directoryName = Path.GetDirectoryName(path1);
            Console.WriteLine(directoryName); // D:\Drivers\Audio\3rd party 
            // 参数是目录，获得目录名，是文件，获得完整文件名
            var fileName = Path.GetFileName(path2);
            Console.WriteLine(fileName); // 测试.txt
            // 获得文件后缀  如果是目录路径，则返回空字符串
            var extension = Path.GetExtension(path2);
            Console.WriteLine(extension); // .txt
            // 获取没有文件后缀的文件名
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path2);
            Console.WriteLine(fileNameWithoutExtension); // 测试
            // 将字符串拼接为路径
            var combine = Path.Combine("D:\\test", "hello.txt"); // D:\test\hello.txt

            Console.WriteLine(combine);
        }

        public static void Case10()
        {
            var directoryPath = "D:/dayl1/demo/te";
            var filePath = directoryPath + "study.txt";
            //1. 判断D盘中是否有 dayl1/demo/te|st目录，没有该目录，创建目录。
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            if (!File.Exists(filePath))
            {
                var fileStream = File.Create(filePath);
                fileStream.Close();
            }

            //2. 向study.txt 文件中添加:
            /*姓名：光头强
                年龄：32
            地址：北京市，昌平区，光头村*/
            var addContent = new[] { "姓名：光头强", "年龄：32", "地址：北京市，昌平区，光头村" };
            File.WriteAllLines(filePath, addContent);

            // 3. 将study.txt 复制一份，复制的文件名为 study-copy.txt。
            File.Copy(filePath, "D:\\study-copy.txt");
        }

        public static void Case9()
        {
            // 创建文件夹
            Directory.CreateDirectory("D:\\test\\test1");
            // 判断转换存在目标文件夹
            Console.WriteLine(Directory.Exists("D:\\test\\test1"));
            // 获取当前工作目录
            Console.WriteLine(Directory.GetCurrentDirectory());
            // 获取指定目录下的所有子目录
            var files = Directory.GetDirectories("D:\\");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            // 获取指定目录下的所有文件名
            var files2 = Directory.EnumerateFiles("D:\\毕设");
            foreach (var file in files2)
            {
                Console.WriteLine(file);
            }

            // 获取指定目录下的所有文件名，方法字符串数组
            var files3 = Directory.GetFiles("D:\\毕设");
            foreach (var file in files3)
            {
                Console.WriteLine(file);
            }

            // 删除目录和子目录，但不能存在文件
            Directory.Delete("D:\\test");
            // 删除目录和子目录，文件也删除
            Directory.Delete("D:\\test", true);
        }

        public static void Case8()
        {
            var path = "D:\\hello2.txt";
            // 方法1
            // File.Copy(path, "D:\\hello3.txt");
            // 方法2
            var readAllBytes = File.ReadAllBytes(path);
            File.WriteAllBytes("D:\\hello3.txt", readAllBytes);
        }

        public static void Case7()
        {
            var path = "D:\\hello2.txt";
            var valLine = "hello";
            // 写入字符串
            File.WriteAllText(path, valLine);
            // 写入字符串数组
            var valLines = new[] { "谢谢", "不用谢" };
            File.WriteAllLines(path, valLines);
            // 写入字节数组
            var valBytes = Encoding.UTF8.GetBytes("见过龙的人是？");
            File.WriteAllBytes(path, valBytes);
            // 追加字符串
            File.AppendAllText(path, "是帝师！");
        }

        public static void Case6()
        {
            var readAllBytes = File.ReadAllBytes(OncePath);
            foreach (var bytes in readAllBytes)
            {
                // 输出的是每个字符的数字编码
                Console.WriteLine(bytes);
            }

            // 转换后打印
            var s = Encoding.UTF8.GetString(readAllBytes, 0, readAllBytes.Length);
            Console.WriteLine(s);
        }

        public static void Case5()
        {
            var readAllText = File.ReadAllText(OncePath);
            Console.WriteLine(readAllText);
        }

        public static void Case4()
        {
            var readAllLines = File.ReadAllLines(OncePath);
            foreach (var line in readAllLines)
            {
                Console.WriteLine(line);
            }
        }

        public static void Case3()
        {
            var readLines = File.ReadLines(OncePath, Encoding.ASCII);
            foreach (var value in readLines)
            {
                Console.WriteLine(value);
            }
        }

        public static void Case2()
        {
            var readLines = File.ReadLines(OncePath);
            foreach (var value in readLines)
            {
                Console.WriteLine(value);
            }
        }

        public static void Case1()
        {
            // 1. 创建文件
            File.Create("D:\\hello.txt");
            // 2. 判断文件是否存在  
            var exists = File.Exists("D:\\hello.txt");
            Console.WriteLine(exists);
            // 3. 复制文件
            File.Copy("D:\\hello.txt", "D:\\hello2.txt");
            // 4. 删除文件
            File.Delete("D:\\hello2.txt");
            // 5. 移动文件
            File.Move("D:\\hello.txt", "D:\\hello3.txt");
        }
    }
}