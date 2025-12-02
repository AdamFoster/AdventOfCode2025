using System.IO;
// 

string filePath = "dayXX/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);

    foreach (string line in fileContents.Trim().Split())
    {
        
    }
    //Console.WriteLine();

}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}