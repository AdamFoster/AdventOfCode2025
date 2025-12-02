using System.IO;
// 5657

string filePath = "day01/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);

    int pos = 50;
    int count = 0;
    foreach (string line in fileContents.Trim().Split())
    //foreach (string line in new List<string>(["L160", "L50"]))
    {
        var amount = int.Parse(line.Substring(1));
        var startPos = pos;
        pos = line[0] == 'L' ? pos - amount : pos + amount;
        var extra = 0;
        if (pos >= 100) 
        {
            extra = pos / 100;
            pos %= 100;
        }
        else if (pos < 0) 
        {
            extra = (100-pos) / 100;
            pos = ((pos % 100) + 100 ) % 100;
            //if (pos == 0) extra++;
            if (startPos == 0) extra--;
        }
        else if (pos == 0) extra++;
        Console.WriteLine(line.Trim() + " -> " + pos + " = " + extra);
        count += extra;
    }
    Console.WriteLine("Total: " + count);

    
}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}