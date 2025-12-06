using System.IO;
using System.Diagnostics;
// 9630000828442


string filePath = "day06/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);
    var stringContents = fileContents.Trim().Split("\n");
    List <List<long>> numbers = new();

    var numset = new List<long>();
    for (int i=0 ; i< stringContents[0].Length ; i++)
    {
        var pieces = Enumerable.Range(0, stringContents.Count()-1).Select(x => stringContents[x][i]);
        if (pieces.All(x => x == ' '))
        {
            numbers.Add(numset);
            numset = new();
        }
        else
        {
            var str = string.Join("", pieces);
            str.Replace(" ", "0");
            numset.Add(long.Parse(str));
            Console.WriteLine(numset[^1]);
        }
    }
    if (numset.Count() > 0) numbers.Add(numset);
    
    var ops = new List<string>(stringContents[^1].Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
    //Console.WriteLine(string.Join(",", ops));
    Debug.Assert(ops.Count == numbers.Count, $"Invalid number of operations {ops.Count} == {numbers.Count}");

    long total = 0;
    for (int i=0 ; i<ops.Count ; i++)
    {
        long subtotal = -1;
        if (ops[i] == "*")
        {
            subtotal = numbers[i].Aggregate(1L, (curr, nxt) => curr * nxt);
        }
        else if (ops[i] == "+")
        {
            subtotal = numbers[i].Aggregate(0L, (curr, nxt) => curr + nxt);
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