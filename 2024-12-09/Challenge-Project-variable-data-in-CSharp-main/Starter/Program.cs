using System;

//���ǵĶ������н��洢�������ݣ�
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// ֧����������ı���
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

// ���ڴ洢����ʱ���ݵ�����
string[,] ourAnimals = new string[maxPets, 7];

// s������������ǵĶ���������Ŀ
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

// �����˵�ѡ��
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

    //�л�case�Դ�����ѡ�˵�ѡ��
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
            //#1��ʾ���ж���������������й�

            string dogCharacteristic = "";

            while (dogCharacteristic == "")
            {
                //#2���û����������ŷָ���������������
                Console.WriteLine($"\r\n����һ��������Ҫ�����Ĺ����������á������ŷָ���");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristic = readResult.ToLower().Trim();
                    Console.WriteLine();
                }
            }

            bool noMatchesDog = true;
            string dogDescription = "";
            
            //#4���¡���ת����������ʱ
            string[] searchingIcons = {"/ ", "-- ", "\\ ","* "};

            //ѭ�����ǵ�Animals����������ƥ��Ķ���
            for (int i = 0; i < maxPets; i++)
            {

                if (ourAnimals[i, 1].Contains("dog"))
                {
                    
                    //������������ͱ�����
                    dogDescription = ourAnimals[i, 4] + "\r\n" + ourAnimals[i, 5];
                    
                    for (int j = 5; j > -1 ; j--)
                    {
                        int countDown = 4;
                    //#5���¡���������Ϣ����ʾ����ʱ
                        foreach (string icon in searchingIcons)
                        {
                            Console.Write($"\rsearching our dog {ourAnimals[i, 3]} for {dogCharacteristic} {icon}{countDown--}");
                            Thread.Sleep(250);
                        }
                        
                        Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                    }
                    
                    //#3a�����ύ�������ʲ�����ÿ���ʵ�����
                    
                    // �������ʴ���ֳ����������飬���������������Ի������ƥ����
                     string[] dogCharacteristicArray =  dogCharacteristic.Split(',');
                    bool isExist = false;
                    foreach (string characteristic in dogCharacteristicArray)
                    {
                        if (dogDescription.Contains(characteristic))
                        {
                            //#3b������Ϣ�Է�ӳ����
                            //#3c����һ����־����ֻ������ƥ���
                            Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a matches your search for {characteristic}!");

                            noMatchesDog = false;
                            isExist = true;
                        }
                       
                    }
                    //#3d�������ֻ������ƥ��дƥ����Ϣ+������
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
                Console.WriteLine("���ǵĹ������ʺ�: " + dogCharacteristic);
            }

            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();

            break;

        default:
            break;
    }

} while (menuSelection != "exit");
