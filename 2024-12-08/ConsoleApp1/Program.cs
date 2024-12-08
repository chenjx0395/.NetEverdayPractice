using System.Linq;

string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
string[] arr1 =  orderStream.Split(',');
Array.Sort(arr1);
string errorMessage = "\t- Error";
for (int i = 0; i < arr1.Length; i++)
{
    if (arr1[i].Length != 4)
    {
        arr1[i] = arr1[i] + errorMessage;
    }
    Console.WriteLine(arr1[i]);
}





void Case01()
{
    string pangram = "The quick brown fox jumps over the lazy dog";
    string[] arr01 = pangram.Split(" ");
    //Array.Reverse(arr01);
    string[] arr02 = new string[arr01.Length];
    for (int i = 0; i < arr01.Length; i++)
    {
        char[] temp = arr01[i].ToCharArray();
        Array.Reverse(temp);
        arr02[i] = new string(temp);
    }
    pangram = String.Join(" ", arr02);
    Console.WriteLine(pangram);

}