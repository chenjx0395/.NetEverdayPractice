using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace _1_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 通过循环创建Xml文件
            //将若干个Person对象存储到xml文档中
            //1.创建一个List<Person>集合
            var persons = new List<Person>() {
                new Person() { Name = "张三", Age = 20, Gender = '男', Id = 1 },
                new Person() { Name = "李四", Age = 25, Gender = '女', Id = 2 },
                new Person() { Name = "王五", Age = 30, Gender = '男', Id = 3 },
                new Person() { Name = "赵六", Age = 35, Gender = '女', Id = 4 }
            };

            //2. 创建XML文件对象
            var xmlDocument = new XmlDocument();
            //3. 添加版本声明和编码格式
            xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null));
            //4. 创建根节点
            var root = xmlDocument.CreateElement("persons");
            //5. 遍历集合，创建子节点并添加到根节点
            foreach (var person in persons)
            {
                //5.1 创建子节点
                var personNode = xmlDocument.CreateElement("person");
                personNode.SetAttribute("id", person.Id.ToString());
                root.AppendChild(personNode);
                //5.2 创建子节点的元素
                personNode.AppendChild(xmlDocument.CreateElement("name")).InnerText = person.Name;
                personNode.AppendChild(xmlDocument.CreateElement("age")).InnerText = person.Age.ToString();
                personNode.AppendChild(xmlDocument.CreateElement("gender")).InnerText = person.Gender.ToString();
                //5.3 将子节点添加到根节点中
                root.AppendChild(personNode);

            }
            xmlDocument.AppendChild(root);
            //6. 保存到xml文件
            xmlDocument.Save("persons.xml");
            #endregion

            #region 查改删
            // 1. 加载XML文件
            var xmlD = new XmlDocument();
            xmlD.Load("persons.xml");
            // 2. 查询所有节点
            var selectSingleNode = xmlD.SelectNodes("/persons/person");
            foreach (XmlElement node in selectSingleNode)
            {
                Console.WriteLine(node.Name);
                Console.WriteLine(node.InnerText);
            }
            // 3. 查询指定ID的节点
            var selectSingleNode1 = xmlD.SelectSingleNode("/persons/person[@id='2']");
            Console.WriteLine(selectSingleNode1.InnerText);

            // 4. 修改节点属性
            selectSingleNode1.Attributes["id"].Value = "666";
            // 5. 修改节点内容
            var singleNode = xmlD.SelectSingleNode("/persons/person[@id='3']/name");
            singleNode.InnerText = "周杰伦";
            // 6. 删除当前节点的属性以及当前节点下的所有子节点
            singleNode.RemoveAll(); 
            // 7. 删除子节点
            var rootNode = xmlD.SelectSingleNode("/persons");
            rootNode.RemoveChild(selectSingleNode1);

            xmlD.Save("persons.xml");

            #endregion
        }

    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public int Id { get; set; }
    }
}