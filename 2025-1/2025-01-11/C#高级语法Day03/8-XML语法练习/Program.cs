using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _8_XML语法练习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //通过C#创建xml文档
            var doc = new XmlDocument();
            //1. 创建文档声明
            var dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            //2. 创建根节点元素
            var books = doc.CreateElement("Books");
            //3. 把文档声明对象和根节点元素添加到xml文档对象中
            doc.AppendChild(dec);
            doc.AppendChild(books);

            //4. 给根节点添加子节点
            var book1 = doc.CreateElement("Book");
            var book2 = doc.CreateElement("Book");
            var book3 = doc.CreateElement("Book");
            //给子节点添加属性
            var id1 = doc.CreateAttribute("ID");
            var id2 = doc.CreateAttribute("ID");
            var id3 = doc.CreateAttribute("ID");
            id1.Value = "1";
            id2.Value = "2";
            id3.Value = "3";
            //把属性和子节点进行绑定
            book1.Attributes.Append(id1);
            book2.Attributes.Append(id2);
            book3.Attributes.Append(id3);
            
            var name1 = doc.CreateElement("Name");
            var name2 = doc.CreateElement("Name");
            var name3 = doc.CreateElement("Name");
            var des1 = doc.CreateElement("des");
            var des2 = doc.CreateElement("des");
            var des3 = doc.CreateElement("des");
            var price1 = doc.CreateElement("Price");
            var price2 = doc.CreateElement("Price");
            var price3 = doc.CreateElement("Price");

            name1.InnerText = "金瓶梅";
            name2.InnerText = "水许传";
            name3.InnerText = "红楼梦";
            des1.InnerText = "好看!!!";
            des2.InnerText = "猴子的恋爱故事";
            des3.InnerText = "—群矫情怪";
            price1.InnerText = "10块钱";
            price2.InnerText = "20块钱";
            price3.InnerText = "30块钱";


            book1.AppendChild(name1);
            book2.AppendChild(name2);
            book3.AppendChild(name3);
            book1.AppendChild(des1);
            book2.AppendChild(des2);
            book3.AppendChild(des3);
            book1.AppendChild(price1);
            book2.AppendChild(price2);
            book3.AppendChild(price3);

            //5.把创建的子节点添加到根节点下
            books.AppendChild(book1);
            books.AppendChild(book2);
            books.AppendChild(book3);

            //保存创建的xml文档
            doc.Save("Books.xml");

        }
    }
}
