const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

int spanFrontIndex = input.IndexOf("<span>");
int spanEndIndex = input.LastIndexOf("</span>");
spanFrontIndex += 6;

string quantity;
 quantity = input.Substring(spanFrontIndex, spanEndIndex - spanFrontIndex);
string output = "";
output = input;
output = output.Replace("<div>", "");
output = output.Replace("</div>", "");
output = output.Replace("&trade", "&reg;");

// Your work here

Console.WriteLine(quantity);
Console.WriteLine(output);


void Case11()
{
    string message = "This--is--ex-amp-le--da-ta";
    message = message.Replace("--", " ");
    message = message.Replace("-", "");
    Console.WriteLine(message);

}

void Case10()
{
    string data = "12345John Smith          5000  3  ";
    string updatedData = data.Remove(5, 20);
    Console.WriteLine(updatedData);
}




void Case9()
{
    string message = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

    //Index Of Any（）辅助方法需要一个字符的char数组。
    //您要查找：

    char[] openSymbols = { '[', '{', '(' };

    //您将使用稍微不同的技术进行迭代
    //字符串中的字符。这次，使用结束符
    //将上一次迭代的位置作为起始索引
    //下一个开放符号。因此，您需要初始化收盘位置
    //变量归零：

    int closingPosition = 0;

    while (true)
    {
        int openingPosition = message.IndexOfAny(openSymbols, closingPosition);

        if (openingPosition == -1) break;

        string currentSymbol = message.Substring(openingPosition, 1);

        //现在找到匹配的结束符号
        char matchingSymbol = ' ';

        switch (currentSymbol)
        {
            case "[":
                matchingSymbol = ']';
                break;
            case "{":
                matchingSymbol = '}';
                break;
            case "(":
                matchingSymbol = ')';
                break;
        }

        //要查找收盘位置，请使用Index of方法的重载来指定
        //搜索匹配的Symbol应从字符串中的开头位置开始。

        openingPosition += 1;
        closingPosition = message.IndexOf(matchingSymbol, openingPosition);

        //最后，使用您已经学会的技术来显示子字符串：

        int length = closingPosition - openingPosition;
        Console.WriteLine(message.Substring(openingPosition, length));
    }
}



void Case8()
{
    string message = "Help (find) the {opening symbols}";
    Console.WriteLine($"Searching THIS Message: {message}");
    char[] openSymbols = { '[', '{', '(' };
    int startPosition = 5;
    int openingPosition = message.IndexOfAny(openSymbols);
    Console.WriteLine($"Found WITHOUT using startPosition: {message.Substring(openingPosition)}");

    openingPosition = message.IndexOfAny(openSymbols, startPosition);
    Console.WriteLine($"Found WITH using startPosition {startPosition}:  {message.Substring(openingPosition)}");
}


void Case07()
{
    string message = "Hello, world!";
    char[] charsToFind = { 'a', 'e', 'i' };

    int index = message.IndexOfAny(charsToFind);

    Console.WriteLine($"Found '{message[index]}' in '{message}' at index: {index}.");
}
void Case06()
{
    //string.IndexOf and string.LastIndexOf Case3
    string message = "(What if) there are (more than) one (set of parentheses)?";
    while (true)
    {
        int openingPosition = message.IndexOf("(");
        int closingPosition = message.IndexOf(")");
        if (openingPosition == -1 || closingPosition == -1)
        {
            Console.WriteLine("没有括号内的内容了！！！");
            break;
        }
        openingPosition += 1;
        string container = message.Substring(openingPosition, closingPosition - openingPosition);
        Console.WriteLine(container);
        closingPosition += 1;
        message = message.Substring(closingPosition); ;
    }
}
void Case05()
{
    //string.IndexOf and string.LastIndexOf Case2
    string message = "(What if) I am (only interested) in the last (set of parentheses)?";
    int openingPosition = message.LastIndexOf('(');

    openingPosition += 1;
    int closingPosition = message.LastIndexOf(')');
    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
}
void Case04()
{
    //string.IndexOf and string.LastIndexOf Case1
    string message = "hello there!";

    int first_h = message.IndexOf('h');
    int last_h = message.LastIndexOf('h');

    Console.WriteLine($"For the message: '{message}', the first 'h' is at position {first_h} and the last 'h' is at position {last_h}.");

}
void Case03()
{

    //string.IndexOf and string.Substirng Case3
    string message = "What is the value <span>between the tags</span>?";

    const string openSpan = "<span>";
    const string closeSpan = "</span>";

    int openingPosition = message.IndexOf(openSpan);
    int closingPosition = message.IndexOf(closeSpan);

    openingPosition += openSpan.Length;
    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));

}
void Case02()
{
    //string.IndexOf and string.Substirng Case2
    string message = "What is the value <span>between the tags</span>?";

    int openingPosition = message.IndexOf("<span>"); //返回的是目标字符串的第一个字符位置
    int closingPosition = message.IndexOf("</span>");

    openingPosition += 6;
    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length));
}


void Case01()
{
    //string.IndexOf and string.Substirng Case1
    string message = "Find what is (inside the parentheses)";

    int openingPosition = message.IndexOf('(');
    int closingPosition = message.IndexOf(')');

    Console.WriteLine(openingPosition);
    Console.WriteLine(closingPosition);

    openingPosition += 1;

    int length = closingPosition - openingPosition;
    Console.WriteLine(message.Substring(openingPosition, length)); // [ 起始，长度 ]
}
