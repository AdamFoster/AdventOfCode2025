using System.IO;
// 

var DIRS = new (int dx, int dy)[]
{
    (-1,-1), 
    (-1, 0), 
    (-1, 1), 
    ( 0,-1), 
    //(0,0), 
    ( 0, 1),
    ( 1,-1), 
    ( 1, 0),
    ( 1, 1)
};

string filePath = "day04/input"; 
try
{
    string fileContents = File.ReadAllText(filePath);

    List<string> lines = new List<string>(fileContents.Trim().Split()).Select(l => l.Trim()).ToList();
    Console.WriteLine(lines.Count() + " x " + lines[0].Length);
    var H = lines.Count();
    var W = lines[0].Length;

    long total = 0;
    var rolls = new HashSet<(int x, int y)>();
    for (int y = 0; y < H; y++)
    {
        for (int x = 0; x < W; x++)
        {
            if (lines[y][x] == '@')
            {
                rolls.Add((x, y));
            }
        }
    }

    bool changed = true;
    while (changed)
    {
        changed = false;
        var newRolls = new HashSet<(int x, int y)>();
        foreach (var (x, y) in rolls)
        {
            int count = 0;

            foreach (var d in DIRS)
            {
                int nx = x + d.dx;
                int ny = y + d.dy;
                if (nx < 0 || nx >= W || ny < 0 || ny >= H)
                {
                    continue;
                }
                char nc = lines[ny][nx];
                if (rolls.Contains((nx, ny)))
                {
                    count++;
                }
            }
            if (count < 4)
            {
                total++;
                changed = true;
                //Console.WriteLine($"Removing roll at ({x},{y}) with {count} neighbors");
            }
            else
            {
                newRolls.Add((x, y));
                //Console.WriteLine($"Keeping roll at ({x},{y}) with {count} neighbors");
            }
            //char c = lines[y][x];
            //Console.Write(c);
        }
        rolls = newRolls;
    }
    Console.WriteLine($"Total: {total}");

}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}