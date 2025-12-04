using System.IO;
// 17095

string filePath = "day03/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);

    int total = 0;
    foreach (string lineOriginal in fileContents.Trim().Split())
    {
        string line = lineOriginal.Substring(0,lineOriginal.Length-1);
        List<char> charList = new List<char>(line.ToCharArray());
        List<int> list = charList.Select(c => int.Parse(c.ToString())).ToList();
        //var set = new HashSet<int>(new List<char>(line.ToCharArray()).Select(c => int.Parse(c.ToString())));
        var set = new HashSet<int>(list);
        var max = set.Max();
        int maxIndex = line.IndexOf(max.ToString());
        //Console.WriteLine(string.Join(", ", set) + $" - Max: {max} Index: {maxIndex}");
        
        line = lineOriginal.Substring(maxIndex + 1);
        set = new HashSet<int>(new List<char>(line.ToCharArray()).Select(c => int.Parse(c.ToString())));
        var max2 = set.Max();
        var amount = $"{max}{max2}";
        total += int.Parse(amount);
        Console.WriteLine(amount);
    }
    Console.WriteLine($"Total: {total}");

}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}