using System;
using System.IO.IsolatedStorage;
using System.Linq.Expressions;
// 丢硬币
//exer01();
// 权限判定
//PermissionJudgment();
// 作用域练习
//DomainsPractice();
// Switch练习
//SwitchCase();
// For练习
//ForCase();
// doWhile练习
//doWhileCase();


bool control = true;
do
{
    Console.WriteLine("请输入5-10之间的数字");
    string? input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input))
    {
        if (int.Parse(input) > 5 && int.Parse(input) < 10)
        {
            control = false;
            Console.WriteLine($"您输入的值是{input}");
        }
    }
}while (control);





void doWhileCase()
{
    int Hero = 10;
    int Monster = 10;
    Random randow = new Random();
    do
    {
        int HeroAttack = randow.Next(1, 11);
        Console.WriteLine($"英雄对怪物造成了{HeroAttack}点伤害");
        Monster -= HeroAttack;
        if (Monster < 0)
        {
            Console.WriteLine("怪兽死了，英雄获胜！");
            break;
        }
        int MonsterAttack = randow.Next(1, 11);
        Console.WriteLine($"怪兽对英雄造成了{MonsterAttack}点伤害");
        Hero -= MonsterAttack;
        if (Hero < 0)
        {
            Console.WriteLine("英雄死了，怪兽获胜！");
            break;
        }
    } while (true);
}

void ForCase()
{
    for (int i = 1; i <= 100; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
            continue;
        }

        if (i % 3 == 0)
            Console.WriteLine("Fizz");
        if (i % 5 == 0)
            Console.WriteLine("Buzz");

        Console.WriteLine();
    }
}

void SwitchCase()
{
    string sku = "01-MN-L";

    string[] product = sku.Split('-');

    string type = "";
    string color = "";
    string size = "";

    switch (product[0])
    {
        case "01":
            type = "Sweat shirt";
            break;
        case "02":
            type = "T-Shirt";
            break;
        case "03":
            type = "Sweat pants";
            break;
        default:
            type = "Other";
            break;
    }

    switch (product[1])
    {
        case "BL":
            color = "Black";
            break;
        case "MN":
            color = "Maroon";
            break;
        default:
            color = "White";
            break;
    }

    switch (product[2])
    {
        case "S":
            size = "Small";
            break;
        case "M":
            size = "Medium";
            break;
        case "L":
            size = "Large";
            break;
        default:
            size = "One Size Fits All";
            break;
    }
    Console.WriteLine($"Product: {size} {color} {type}");
}

void DomainsPractice()
{
    int[] numbers = { 4, 8, 15, 16, 23, 42 };
    bool found = false;
    int total = 0;
    foreach (int number in numbers)
    {

        total += number;

        if (number == 42)
        {
            found = true;

        }

    }
    if (found)
        Console.WriteLine("Set contains 42");
    Console.WriteLine($"Total: {total}");
}



void PermissionJudgment()
{
    string permission = "Admin|Manager";
    int level = 55;
    if (permission.Contains("Admin"))
    {
        if (level > 55)
            Console.WriteLine("欢迎，超级管理员用户。");
        else
            Console.WriteLine("欢迎，管理员用户。");
    }
    else if (permission.Contains("Manager"))
    {
        if (level >= 20)
            Console.WriteLine("您没有足够的权限。");
        else
            Console.WriteLine("您没有足够的权限。");
    }
    else
        Console.WriteLine("您没有足够的权限。");
}

void exer01()
{
    Random random = new Random();
    int randomResult = random.Next(0, 2);
    Console.WriteLine(randomResult == 1 ? "tails" : "heads");
}

