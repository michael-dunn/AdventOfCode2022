using System.Threading.Tasks.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var items = new List<char>();
        int total = 0;

        foreach (var rucksack in fileData)
        {
            var compartentSize = rucksack.Length / 2;

            var firstCompartment = rucksack.Take(compartentSize);
            var secondCompartment = rucksack.Skip(compartentSize);

            foreach (var item in firstCompartment)
            {
                if (secondCompartment.Contains(item))
                {
                    items.Add(item);
                    if (item < 97)
                    {
                        total += item - 64 + 26;
                    }
                    else
                    {
                        total += item - 96;
                    }
                    break;
                }
            }
        }
        Console.WriteLine(total);
    }
}