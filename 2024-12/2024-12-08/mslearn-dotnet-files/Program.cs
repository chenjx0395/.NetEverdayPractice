using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine(currentDirectory);
var storesDirectory = Path.Combine(currentDirectory, "stores");
// 销售业绩总额文件夹
var salesTotalDir = Path.Combine(storesDirectory, "salesTotalDir");
//创建文件夹
// Directory.CreateDirectory(salesTotalDir);
//创建文件写入空字符串
// File.WriteAllText(Path.Combine(salesTotalDir,"totals.txt"),string.Empty);
//读文件

string salesJson  =  File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");



var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
Console.WriteLine(salesData.Total);

File.WriteAllText($"stores{Path.DirectorySeparatorChar}salesTotalDir{Path.DirectorySeparatorChar}totals.txt", salesData.Total.ToString());
File.AppendAllText($"stores{Path.DirectorySeparatorChar}salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{salesData.Total}{Environment.NewLine}");

class SalesTotal
{
  public double Total { get; set; }
}
// Console.WriteLine(storesDirectory);

// var salesFiles = FindFiles(storesDirectory);

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

// 查找指定目录下的指定后缀文件

// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         var extension = Path.GetExtension(file);
//         // 文件名将包含完整的路径，所以只检查它的末尾
//         if (extension == ".json")
//         {
//             salesFiles.Add(file);
//         }
//     }

//     return salesFiles;
// }