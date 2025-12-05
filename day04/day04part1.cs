using System.IO;
// 1411

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
    for (int y = 0; y < H; y++)
    {
        for (int x = 0; x < W; x++)
        {
            int count = 0;
            if (lines[y][x] != '@')
            {
                continue;
            }
            foreach (var d in DIRS)
            {
                int nx = x + d.dx;
                int ny = y + d.dy;
                if (nx < 0 || nx >= W || ny < 0 || ny >= H)
                {
                    continue;
                }
                char nc = lines[ny][nx];
                if (nc == '@')
                {
                    count++;
                    //Console.write('+');
                }

            }
            if (count < 4)
            {
                total++;
            }
            //char c = lines[y][x];
            //Console.Write(c);
        }
    }
    Console.WriteLine($"Total: {total}");

}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}");
}