using System.IO;
// 168794698570517

(int, int, string) GetMax(string lineLeft, int stepsLeft)
{
    string line = lineLeft.Substring(0,lineLeft.Length-stepsLeft+1);
    List<char> charList = new List<char>(line.ToCharArray());
    List<int> list = charList.Select(c => int.Parse(c.ToString())).ToList();
    var set = new HashSet<int>(list);
    var max = set.Max();
    int maxIndex = line.IndexOf(max.ToString());
    return (max, maxIndex, lineLeft.Substring(maxIndex + 1));
}

string filePath = "day03/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);

    long total = 0;
    foreach (string lineOriginal in fileContents.Trim().Split())
    {
        string remainingLine = lineOriginal;
        long subtotal = 0;
            
        for (int i = 12; i > 0; i--)
        {
            (int max, int maxIndex, remainingLine) = GetMax(remainingLine, i);
            subtotal = subtotal * 10 + max;

            //Console.WriteLine($"Step {i}: Max: {max} Index: {maxIndex} Remaining: {remainingLine}");
        }
        total += subtotal;
        Console.WriteLine($"Subtotal: {subtotal}");
    }
    Console.WriteLine($"Total: {total}");

}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}