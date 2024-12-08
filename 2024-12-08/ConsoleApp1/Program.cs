using System.Linq;

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
pangram =  String.Join(" ",arr02);
Console.WriteLine(pangram);
