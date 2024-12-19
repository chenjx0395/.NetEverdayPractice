//string.Format 内插字符串
//string first = "Hello";
//string second = "World";
//string result = string.Format("{0} {1}!", first, second);
//Console.WriteLine(result);

//string.padLeft() and string.padRight 左右添加空格或其他字符
//string input = "Pad this";
//Console.WriteLine(input.PadLeft(12));
//Console.WriteLine(input.PadRight(12));
//Console.WriteLine(input.PadLeft(12,'*'));
//Console.WriteLine(input.PadRight(12,'-'));

//string paymentId = "769C";
//string payeeName = "Mr. Stephen Ortega";
//string paymentAmount = "$5,000.00";
//var formattedLine = paymentId.PadRight(6);
//formattedLine += formattedLine += payeeName.PadRight(24);
//formattedLine += paymentAmount.PadLeft(10);
//Console.WriteLine("1234567890123456789012345678901234567890");
//Console.WriteLine(formattedLine); 

// 综合练习
string customerName = "Ms. Barros";
string padCustomerName = customerName.PadRight(20);

string currentProduct = "Magic Yield";
string padCustomerProduct = customerName.PadRight(20);

int currentShares = 2975000;
decimal currentReturn = 0.1275m;
string padCurrentReturn = 0.1275m.ToString().PadRight(10);
decimal currentProfit = 55000000.0m;

string newProduct = "Glorious Future";
decimal newReturn = 0.13125m;
string padNewReturn = 0.13125m.ToString().PadRight(10);
decimal newProfit = 63000000.0m;

// Your logic here

Console.WriteLine("Here's a quick comparison:\n");

string comparisonMessage = $""""
    Dear {customerName},
    As a customer of our Magic Yield offering we are excited to tell you about a new financial product that would dramatically increase your return.

    Currently, you own {currentShares:N2}shares at a return of {currentReturn:P2}.

    Our new product, Glorious Future offers a return of {newReturn:P2}.  Given your current volume, your potential profit would be {newProfit:C2}.

    Here's a quick comparison:

    {padCustomerName}{currentReturn:P2}   {currentProfit:C2}
    {padCustomerProduct}{newReturn:P2}   {newProfit:C2}
    """";

// Your logic here

Console.WriteLine(comparisonMessage);