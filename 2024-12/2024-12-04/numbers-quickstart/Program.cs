//WorkWithIntegers();
//TestLimits()
    
void TestLimits()
{
    int n1 = 9 / 5;
    Console.WriteLine(n1);

    Console.WriteLine($"最小值：{int.MinValue} 最大值： {int.MaxValue}");
    var max = int.MaxValue;
    max++;
    Console.WriteLine($"测试最大值溢出情况 {max}");

    var min = int.MinValue;
    min--;
    Console.WriteLine($"测试最小值溢出情况 {min}");
}


void WorkWithIntegers()
{
    int a = 18;
    int b = 6;
    int c = a + b;
    Console.WriteLine(c);


    // subtraction
    c = a - b;
    Console.WriteLine(c);

    // multiplication
    c = a * b;
    Console.WriteLine(c);

    // division
    c = a / b;
    Console.WriteLine(c);
}