using System.IO;
// 30323879646

string filePath = "day02/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);

    long total = 0;
    foreach (string line in fileContents.Trim().Split(','))
    //foreach (string line in new List<string>(["998-1012"]))
    {
        if (line.Trim().Split('-') is [string part1, string part2])
        {
            var start = long.Parse(part1);
            var end = long.Parse(part2);
            Console.WriteLine($"{start}-{end}");

            for (long i=start; i<=end; i++)
            {
                string istring = i.ToString();
                if (istring.Length % 2 == 0)
                {
                    string first = istring.Substring(0, istring.Length/2);
                    string second = istring.Substring(istring.Length/2, istring.Length/2);
                    if (first.Equals(second))
                    {
                        total += i;
                        Console.WriteLine($"{first}/{second}");
                    }
                }
            }
        }
    }
    Console.WriteLine("Total = " + total);
    //Console.WriteLine();
}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}