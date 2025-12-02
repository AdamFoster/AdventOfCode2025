using System.IO;
// 984

string filePath = "day01/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);

    int pos = 50;
    int count = 0;
    foreach (string line in fileContents.Trim().Split())
    {
        var amount = int.Parse(line.Substring(1));
        pos = line[0] == 'L' ? pos - amount : pos + amount;
        pos = (pos + 100) % 100;
        if (pos == 0) count++;
        Console.WriteLine(line.Trim() + " -> " + pos);
    }
    Console.WriteLine("Total: " + count);

    
}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}