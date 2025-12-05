using System.IO;
// 353507173555373

string filePath = "day05/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);

    long fresh = 0;
    var ranges = new List<(long start, long end)>();

    foreach (string line in fileContents.Trim().Split())
    {
        if (line.Length == 0)
        {
            break;
        }

        var parts = line.Split('-');
        var start = long.Parse(parts[0]);
        var end = long.Parse(parts[1]);
        ranges.Add((start, end));

    }

    ranges = ranges.OrderBy(r => r.start).ThenBy(r => r.end).ToList();
    var done = false;
    
    while (!done)
    {
        done = true;
        int i=0;
        while (i < ranges.Count-1)
        {
            if (ranges[i].end >= ranges[i+1].start - 1)
            {
                ranges[i] = (ranges[i].start, Math.Max(ranges[i].end, ranges[i+1].end));
                ranges.RemoveAt(i+1);
                done = false;
                continue;
            }
            i++;
        }
    }
    for (int i = 0; i < ranges.Count; i++)
    {
        Console.WriteLine($"Range: {ranges[i].start}-{ranges[i].end}");
        fresh += ranges[i].end - ranges[i].start + 1;
    }

    Console.WriteLine($"Fresh: {fresh}");

}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}