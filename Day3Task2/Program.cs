using System.Drawing;

public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var items = new List<char>();
        int total = 0;
        
        foreach (var elfGroup in fileData.Select((s, i) => fileData.Skip(i * 3).Take(3)).Where(a => a.Any()))
        {
            foreach(var item in elfGroup.First())
            {
                if (elfGroup.Skip(1).First().Contains(item) && elfGroup.Skip(2).First().Contains(item))
                {
                    items.Add(item);
                    if (item < 97)
                    {
                        total += item - 38;
                    }
                    else
                    {
                        total += item - 96;
                    }
                    break;
                }
            }
        }
        Console.WriteLine(string.Join(", ", items));
        Console.WriteLine(total);
    }
}