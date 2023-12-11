List<string> lines = new();
using (StreamReader reader = new(args[0]))
{
    while (!reader.EndOfStream)
    {
        lines.Add(reader.ReadLine());
    }
}

solve(2);
solve(1000000);

void solve(uint dark_energy)
{
List<uint> lines_cost = new();

/*
 * any rows or columns that contain no galaxies should all actually be twice as big. (part 2 1M x big)
 */
foreach (string line in lines)
{
    bool emptyLine=true;
    foreach (char c in line)
    {
        if (c != '.')
        {
            emptyLine = false;
            break;
        }
    }
    if(emptyLine)
        lines_cost.Add(dark_energy);
    else
        lines_cost.Add(1);
}

List<uint> cols_cost = new();
for (int j = 0; j < lines[0].Length; j++)
{
    bool emptyCol = true;
    for (int i = 0; i < lines.Count; i++)
    {
        if (lines[i][j] != '.')
        {
            emptyCol = false;
            break;
        }
    }
    if(emptyCol)
        cols_cost.Add(dark_energy);
    else
        cols_cost.Add(1);
}

List<coord> galaxies = new List<coord>();
for (int i=0;i<lines.Count;i++)
    for(int j = 0; j < lines[i].Length;j++)
        if(lines[i][j]=='#') galaxies.Add(new(i, j));


ulong total = 0;
for (int i = 0; i < galaxies.Count; i++)
{
    for (int j = i+1; j < galaxies.Count; j++)
    {
        coord from = galaxies[i];
        coord dest = galaxies[j];
        coord traveling = new(from.x, from.y);
        ulong distance = 0;
        while (traveling.x != dest.x)
        {
            if (traveling.x < dest.x)
                traveling.x++;
            else
                traveling.x--;
            distance += lines_cost[traveling.x];
        }
        while(traveling.y!=dest.y)
        {
            if (traveling.y < dest.y)
                traveling.y++;
            else
                traveling.y--;
            distance+= cols_cost[traveling.y];
        }
        total += distance;
    }
}

Console.WriteLine(total);
}

struct coord
{
    public int x;
    public int y;
    public coord(int x, int y)
    {
        this.x = x; this.y = y;
    }
}