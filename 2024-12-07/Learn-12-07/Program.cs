string value = "abc123";
char[] valueArray = value.ToCharArray();
Array.Reverse(valueArray);
//string result = new string(valueArray);
string result = String.Join(",", valueArray);
Console.WriteLine(result);
string[] items = result.Split(',');
foreach (string item in items)
{
    Console.WriteLine(item);
}


void case05()
{


}
void case04()
{


}
void case03()
{
    string[] pallets = ["B14", "A11", "B12", "A13"];
    Console.WriteLine("");

    Array.Clear(pallets, 0, 2);
    Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }

    Console.WriteLine("");
    Array.Resize(ref pallets, 6);
    Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

    pallets[4] = "C01";
    pallets[5] = "C02";

    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }

    Console.WriteLine("");
    Array.Resize(ref pallets, 3);
    Console.WriteLine($"Resizing 3 ... count: {pallets.Length}");

    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }

}

void case02()
{
    string[] pallets = ["B14", "A11", "B12", "A13"];

    Console.WriteLine("Sorted...");
    Array.Sort(pallets);
    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }

    Console.WriteLine("");
    Console.WriteLine("Reversed...");
    Array.Reverse(pallets);
    foreach (var pallet in pallets)
    {
        Console.WriteLine($"-- {pallet}");
    }

}

void case01()
{
    int value1 = 11;
    decimal value2 = 6.2m;
    float value3 = 4.3f;

    //您在此处设置结果1的代码
    //提示：您需要将结果四舍五入到最接近的整数（不要只是截断）
    Console.WriteLine($"将value1除以value2，将结果显示为整数: {Convert.ToInt32((value1 / value2))}");

    //您在此处设置result2的代码
    Console.WriteLine($"将值2除以值3，将结果显示为小数: {value2 / (decimal)value3}");

    //您在此处设置result3的代码
    Console.WriteLine($"将值3除以值1，将结果显示为浮点数: {value3 / (float)value1}");

}