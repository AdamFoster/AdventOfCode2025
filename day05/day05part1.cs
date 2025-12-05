using System.IO;
// 623

string filePath = "day05/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);

    int fresh = 0;
    var rangesMode = true;
    var ranges = new List<(long start, long end)>();
    foreach (string line in fileContents.Trim().Split())
    {
        if (line.Length == 0)
        {
            rangesMode = false;
            continue;
        }

        if (rangesMode)
        {
            var parts = line.Split('-');
            var start = long.Parse(parts[0]);
            var end = long.Parse(parts[1]);
            ranges.Add((start, end));
        }
        else
        {
            var num = long.Parse(line);
            foreach (var (start, end) in ranges)
            {
                if (num >= start && num <= end)
                {
                    Console.WriteLine($"{num} is in range {start}-{end}");
                    fresh++;
                    break;
                }
            }
        }
    }
    Console.WriteLine($"Fresh: {fresh}");

}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}