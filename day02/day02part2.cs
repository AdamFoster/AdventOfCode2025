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

            for (long testNum=start; testNum<=end; testNum++)
            {
                string istring = testNum.ToString();
                for (int len=1 ; len<=istring.Length/2 ; len++)
                {
                    //Console.WriteLine($"Checking {testNum} with length {len}");
                    if (istring.Length % len != 0) continue;
                    string first = istring.Substring(0, len);
                    string bites = istring.Substring(len);
                    while (bites.StartsWith(first))
                    {
                        bites = bites.Substring(len);
                    }
                    if (bites.Length == 0)
                    {
                        Console.WriteLine($"{first} <- {istring}");
                        total += testNum;
                        break;
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