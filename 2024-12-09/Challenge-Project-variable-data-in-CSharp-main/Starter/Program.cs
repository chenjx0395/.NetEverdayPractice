using System;

//我们的动物阵列将存储以下内容：
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// 支持数据输入的变量
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

// 用于存储运行时数据的数组
string[,] ourAnimals = new string[maxPets, 7];

// s充足的数据我们的动物数组条目
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
            suggestedDonation = "49.99";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "snow";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "lion";
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
    
    if (!decimal.TryParse(suggestedDonation, out decimalDonation)){
        decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

// 顶级菜单选项
do
{
    // NOTE: the Console.Clear method is throwing an exception in debug sessions
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    //切换case以处理所选菜单选项
    switch (menuSelection)
    {
        case "1":
            // list all pet info
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j].ToString());
                    }
                }
            }

            Console.WriteLine("\r\nPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        case "2":
            //#1显示具有多个搜索特征的所有狗

            string dogCharacteristic = "";

            while (dogCharacteristic == "")
            {
                //#2让用户输入多个逗号分隔的特征进行搜索
                Console.WriteLine($"\r\n输入一个或多个想要搜索的狗特征（请用“，”号分隔）");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                    Console.WriteLine();
                }
            }

            bool noMatchesDog = true;
            string dogDescription = "";
            
            //#4更新“旋转”动画倒计时
            string[] searchingIcons = {"/ ", "-- ", "\\ ","* "};

            //循环我们的Animals数组以搜索匹配的动物
            for (int i = 0; i < maxPets; i++)
            {

                if (ourAnimals[i, 1].Contains("dog"))
                {
                    
                    //搜索组合描述和报告结果
                    dogDescription = ourAnimals[i, 4] + "\r\n" + ourAnimals[i, 5];
                    
                    for (int j = 5; j > -1 ; j--)
                    {
                        int countDown = 4;
                    //#5更新“搜索”消息以显示倒计时
                        foreach (string icon in searchingIcons)
                        {
                            Console.Write($"\rsearching our dog {ourAnimals[i, 3]} for {dogCharacteristic} {icon}{countDown--}");
                            Thread.Sleep(250);
                        }
                        
                        Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                    }
                    
                    //#3a迭代提交的特征词并搜索每个词的描述
                    
                    // 将描述词串拆分成描述词数组，遍历描述词数组以获得所有匹配结果
                     string[] dogCharacteristicArray =  dogCharacteristic.Split(',');
                    bool isExist = false;
                    foreach (string characteristic in dogCharacteristicArray)
                    {
                        if (dogDescription.Contains(characteristic))
                        {
                            //#3b更新消息以反映术语
                            //#3c设置一个标志“这只狗”是匹配的
                            Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a matches your search for {characteristic}!");

                            noMatchesDog = false;
                            isExist = true;
                        }
                       
                    }
                    //#3d如果“这只狗”是匹配写匹配消息+狗描述
                    if(isExist)
                    {
                        Console.WriteLine($"DogInfo:{ourAnimals[i, 1]}");
                        Console.WriteLine($"DogInfo:{ourAnimals[i, 2]}");
                        Console.WriteLine($"DogInfo:{ourAnimals[i, 3]}");
                        Console.WriteLine($"DogInfo:{ourAnimals[i, 4]}");
                        Console.WriteLine($"DogInfo:{ourAnimals[i, 5]}");
                        Console.WriteLine($"DogInfo:{ourAnimals[i, 6]}");
                    }
                }
            }

            if (noMatchesDog)
            {
                Console.WriteLine("我们的狗都不适合: " + dogCharacteristic);
            }

            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        default:
            break;
    }

} while (menuSelection != "exit");
