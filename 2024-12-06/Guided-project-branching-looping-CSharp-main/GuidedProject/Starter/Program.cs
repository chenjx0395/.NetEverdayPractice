//我们的Animals数组将存储以下内容：
// 动物种类
string animalSpecies = "";
string animalID = "";
string animalAge = "";
//外表描述
string animalPhysicalDescription = "";
//性格描述 
string animalPersonalityDescription = "";
string animalNickname = "";

//支持数据输入的变量
int maxPets = 8;
string? readResult;
string menuSelection = "";

//用于存储运行时数据的数组，没有持久化数据
string[,] ourAnimals = new string[maxPets, 6];

//TODO:将if-elseif-else构造转换为switch语句

//创建一些初始的Animals数组条目
for (int i = 0; i < maxPets; i++)
{
    if (i == 0)
    {
        animalSpecies = "dog";
        animalID = "d1";
        animalAge = "2";
        animalPhysicalDescription = "中等大小的奶油色雌性金毛寻回犬，体重约65磅。房子破了。";
        animalPersonalityDescription = "喜欢揉她的肚子，喜欢追她的尾巴。给了很多吻。";
        animalNickname = "lola";
    }
    else if (i == 1)
    {
        animalSpecies = "dog";
        animalID = "d2";
        animalAge = "9";
        animalPhysicalDescription = "大型红棕色雄性金毛寻回犬，体重约85磅。房子破了。";
        animalPersonalityDescription = "当他在门口或任何时候问候你时，他都喜欢揉耳朵！喜欢靠在身上给小狗拥抱。";
        animalNickname = "loki";
    }
    else if (i == 2)
    {
        animalSpecies = "cat";
        animalID = "c3";
        animalAge = "1";
        animalPhysicalDescription = "体重约8磅的白色小雌性。垃圾箱训练。";
        animalPersonalityDescription = "友好的";
        animalNickname = "Puss";
    }
    else if (i == 3)
    {
        animalSpecies = "cat";
        animalID = "c4";
        animalAge = "?";
        animalPhysicalDescription = "";
        animalPersonalityDescription = "";
        animalNickname = "";
    }
    else
    {
        animalSpecies = "";
        animalID = "";
        animalAge = "";
        animalPhysicalDescription = "";
        animalPersonalityDescription = "";
        animalNickname = "";
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

//显示顶级菜单选项

Console.Clear();

Console.WriteLine("欢迎使用Contoso宠物朋友应用程序。您的主菜单选项包括：");
Console.WriteLine(" 1.列出我们当前所有的宠物信息");
Console.WriteLine(" 2.在我们的动物数组中添加一个新的动物朋友");
Console.WriteLine(" 3.确保动物年龄和身体描述完整");
Console.WriteLine(" 4.确保动物昵称和个性描述完整");
Console.WriteLine(" 5.编辑动物的年龄");
Console.WriteLine(" 6.编辑动物的性格描述");
Console.WriteLine(" 7.显示具有指定特征的所有猫");
Console.WriteLine(" 8.显示具有指定特征的所有狗");
Console.WriteLine();
Console.WriteLine("输入您的选择号（或键入Exit退出程序)");

readResult = Console.ReadLine();
if (readResult != null)
{
    menuSelection = readResult.ToLower();
}

Console.WriteLine($"您选择了菜单选项 {menuSelection}.");
Console.WriteLine("按Enter键继续");

// pause code execution
readResult = Console.ReadLine();
