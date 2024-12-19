using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using ContactSystem;
// 控制系统是否运行
bool isOut = true;
// 从本地文件中读取联系人
List<Contact> contacts = LoadFromFile();
// 文件存储名
const string FileName = "contacts.json";

while (isOut)
{
    InterfaceDisplay();
    InterfaceDisplayControl();
}

// 系统视图
void InterfaceDisplay()
{
    Console.WriteLine(""" 
  ************个人联系人系统*************
                1. 添加新联系人
                2. 修改联系人
                3. 删除联系人
                4. 查询联系人
                5. 查询全部联系人
                6. 存储到本地
                7. 退出
                请选择【1-7】的功能
  """);
}
// 系统功能控制
void InterfaceDisplayControl()
{
    ConsoleKeyInfo instructInfo;
    instructInfo = Console.ReadKey();
    Console.WriteLine();
    switch (instructInfo.KeyChar)
    {
        case '1':
            Console.WriteLine("请输入添加的联系人姓名");
            string? addName = Console.ReadLine();
            Console.WriteLine("请输入添加的联系人电话");
            string? addPhone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(addName)  || string.IsNullOrWhiteSpace(addPhone))
            {
                Console.WriteLine("添加失败，不允许姓名或电话为空");
            }
            else
            {
                AddContact(addName,addPhone);
            }
            break;
        case '2':
            Console.WriteLine("请输入修改的联系人姓名");
            string? oldName = Console.ReadLine();
            Console.WriteLine("请输入修改后的联系人姓名");
            string? newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("添加失败，不允许姓名为空");
            }
            else
            {
                UpdateContact(oldName, newName);
            }
            break;
        case '3':
            Console.WriteLine("请输入要删除的联系人姓名");
            string? deleteName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(deleteName))
            {
                Console.WriteLine("添加失败，不允许姓名为空");
            }
            else
            {
                DeleteContact(deleteName);
            }
            break;
        case '4':
            Console.WriteLine("请输入要搜索联系人的关键字");
            string? searchName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(searchName))
            {
                Console.WriteLine("搜索失败，不允许姓名为空");
            }
            else
            {
                FuzzyLookup(searchName);
            }
            break;
        case '5':
            SelectAllContact();
            break;
        case '6':
            SaveToFile();
            break;
        case '7':
            OutSystem();
            break;
        default:
            Console.WriteLine("非法的输入，请重新输入");
            break;
    }
}

//添加联系人
void AddContact(string name,string phone)
{
    // 如果存在同名联系人则不允许添加
    if (IsExist(name))
    {
        Console.WriteLine("添加失败！存在同名联系人!");
    }
    else
    {
        contacts.Add(new Contact(name,phone));
        Console.WriteLine("联系人添加成功！");
    }
}

//修改联系人
void UpdateContact(string oldName, string newName)
{
    int nameIndex = ExistIndex(oldName);
    //查找，删除，添加 实现修改
    if (!IsExist(oldName))
    {
        Console.WriteLine("修改失败！查无此人！");
        return;
    }
    if (ExistIndex(newName) != -1)
    {
        Console.WriteLine("修改失败！存在同名联系人！");
        return;
    }
    if (nameIndex != -1)
    {
        // 查询此联系人电话，方便后续添加
        string phone = contacts[nameIndex].Phone;
        contacts.RemoveAt(nameIndex);
        AddContact(newName, phone);
        Console.WriteLine("修改成功！");
    }

}

//删除联系人
void DeleteContact(string name)
{
    int contactIndex = ExistIndex(name);
    if (contactIndex == -1)
    {
        Console.WriteLine("删除失败！查无此人！");
        return;
    }
    contacts.RemoveAt(contactIndex);
    Console.WriteLine("删除成功！");

}
//模糊查找联系人
void FuzzyLookup(string nameKey)
{
    foreach (Contact contact in contacts)
    {
        if (contact.Name.Contains(nameKey))
        {
            Console.WriteLine($"联系人：{contact.Name}  电话：{contact.Phone}");
        }
    }
   
}

//查询全部联系人
void SelectAllContact()
{
    foreach (Contact contact in contacts)
    {
        Console.WriteLine($"联系人：{contact.Name}  电话：{contact.Phone}");
    }
}


//存储联系人至本地文件
void SaveToFile()
{
    try
    {
        string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);
        Console.WriteLine("数据已成功保存到文件。");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"保存数据时出错: {ex.Message}");
    }
}
//读取本地文件的联系人
 List<Contact> LoadFromFile()
{
    try
    {
        if (!File.Exists(FileName))
        {
            Console.WriteLine("您未存储过联系人，欢迎使用本系统存储联系人！");
            return new List<Contact>();
        }

        string json = File.ReadAllText(FileName);
        List<Contact>? contacts = JsonSerializer.Deserialize<List<Contact>>(json);
        Console.WriteLine("数据已成功从文件读取。");
        return contacts ?? new List<Contact>();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"读取数据时出错: {ex.Message}");
        return new List<Contact>();
    }
}


//退出系统方法
void OutSystem()
{
    Console.WriteLine("系统即将退出!欢迎你下次使用！");
    isOut = false;
}

//返回联系人集合中对于姓名索引
int ExistIndex(string name)
{
    int count = 0;
    foreach (Contact contact in contacts)
    {
        if (contact.Name == name)
        {
            return count;
        }
        count++;
    }
    return -1;
}

//判定联系人列表中是否存在此输入姓名
bool IsExist(string name)
{
    if (ExistIndex(name) == -1)
    {
        return false;
    }
    return true;
}