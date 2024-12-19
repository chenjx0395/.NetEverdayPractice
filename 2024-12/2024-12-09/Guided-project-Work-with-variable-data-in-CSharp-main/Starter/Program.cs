// #1 我们的Animals数组将存储以下内容：
// 动物种类
string animalSpecies = "";
string animalID = "";
string animalAge = "";
// 动物外表描述
string animalPhysicalDescription = "";
// 动物性格描述
string animalPersonalityDescription = "";
// 动物名称
string animalNickname = "";
// 建议捐赠
string suggestedDonation = "";
decimal decimalDonation = 0.00m;

// #2 支持数据输入的变量
// 最大宠物数
int maxPets = 8;
string? readResult;
// 菜单选择
string menuSelection = "";

// #3 用于存储运行时数据的数组，没有持久化数据
string[,] ourAnimals = new string[maxPets, 7];

// #4 在Animals数组条目中创建示例数据
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "gus";
            suggestedDonation = "66.00";
            break;
        
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "snow";
            suggestedDonation = "45.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "3";
            animalPhysicalDescription = "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
            animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
            animalNickname = "Lion";
            suggestedDonation = "";
            break;
        
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    ourAnimals[i, 6] = "Suggested Donation: " + suggestedDonation;
    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m; // 如果建议捐赠不是数字，则默认为45.00
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}


// #5 显示顶级菜单选项
do
{
    // NOTE: 控制台。Clear方法在调试会话中抛出异常
    Console.Clear();

    Console.WriteLine("欢迎使用Contoso宠物朋友应用程序。您的主菜单选项包括：");
    Console.WriteLine(" 1. 列出我们当前所有的宠物信息");
    Console.WriteLine(" 2. 显示具有指定特征的所有狗");
    Console.WriteLine();
    Console.WriteLine("输入您的选择号（或键入Exit退出程序)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // 使用switch case处理所选菜单选项
    switch (menuSelection)
    {
        case "1":
            // list all pet info
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++) // 增加退出条件
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "2":
            // 狗的特征
            string dogCharacteristic = "";
            while (dogCharacteristic == "")
            {
                // 让用户输入要搜索的物理特征
                Console.WriteLine($"\n输入一个所需的狗特征进行搜索");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                }
            }
            // 显示具有指定特征的所有狗
            string dogDescription = "";
            bool noMatchesDog = true;
            // #6 遍历我们的Animals数组以搜索匹配的动物
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("dog"))
                {
                    // #7 搜索组合描述和报告结果
                    dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                    if (dogDescription.Contains(dogCharacteristic))
                    {
                        Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match!");
                        Console.WriteLine(dogDescription);

                        noMatchesDog = false;
                    }
                }
            }
            if (noMatchesDog)
            {
                Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");
