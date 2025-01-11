using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Calculator_Component_Rule;
namespace Calculator_Component_Factory
{
    public class ComponentFactory
    {
        /// <summary>
        /// 加载插件目录下的所有插件并返回插件集合
        /// </summary>
        /// <returns></returns>
        public static List<ComponentRule> LoadPlugIns()
        {
            var plugs = new List<ComponentRule>();
            //1. 获取插件目录
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            path = Path.Combine(path, "Component_Plug_In");
            //2. 读取该路径的所有文件
            var paths = Directory.GetFiles(path);
            foreach (var filePath in paths)
            {
                var assembly = Assembly.LoadFile(filePath);
                //3. 获取当前程序集的公共类型
                var types = assembly.GetExportedTypes();
                //4. 将符合标准的类添加至返回集合中
                foreach (var type in types)
                {
                    if (!typeof(ComponentRule).IsAssignableFrom(type) || type.IsAbstract) continue;
                    // 创建实例对象添加入集合中
                    var instance = Activator.CreateInstance(type);
                    plugs.Add((ComponentRule)instance);
                }

            }
            return plugs;
        }
    }
}