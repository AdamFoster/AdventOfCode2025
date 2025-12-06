using System.IO;
using System.Diagnostics;
// 5977759036837


string filePath = "day06/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);
    var stringContents = fileContents.Trim().Split("\n");
    List <List<int>> numbers = new();
    foreach (string line in stringContents[..^1])
    {
        var sl = new List<string>(line.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
        var il = sl.Select(int.Parse).ToList();
        numbers.Add(il);
        //Console.WriteLine(string.Join(",", il));
    }
    var ops = new List<string>(stringContents[^1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
    //Console.WriteLine(string.Join(",", ops));
    Debug.Assert(ops.Count == numbers[0].Count, "Invalid number of operations");

    long total = 0;
    for (int i=0 ; i<ops.Count ; i++)
    {
        long subtotal = -1;
        if (ops[i] == "*")
        {
            Console.WriteLine(string.Join(";", Enumerable.Range(0, numbers.Count).Select(x => numbers[x][i])));
            subtotal = Enumerable.Range(0, numbers.Count).Aggregate(1L, (curr, nxt) => curr * numbers[nxt][i]);
        }
        else if (ops[i] == "+")
        {
            Console.WriteLine(string.Join(";", Enumerable.Range(0, numbers.Count).Select(x => numbers[x][i])));
            subtotal = Enumerable.Range(0, numbers.Count).Aggregate(0L, (curr, nxt) => curr + numbers[nxt][i]);
        }
        else
        {
            Debug.Assert(false, "Invalid op");
        }
        Console.WriteLine($"Subtotal: {subtotal}");
        total += subtotal;

    }
    Console.WriteLine($"Total: {total}");

}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}