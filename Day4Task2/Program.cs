public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var overlaps = 0;
        foreach (var elfPair in fileData)
        {
            var elfSections = elfPair.Split(',').Select(s => s.Split('-').Select(s => int.Parse(s)));

            var elf1Section = elfSections.First();
            var elf2Section = elfSections.Skip(1).First();

            if (InBetween(elf1Section.First(), elf2Section.First(), elf2Section.Skip(1).First()) || InBetween(elf1Section.Skip(1).First(), elf2Section.First(), elf2Section.Skip(1).First()))
            {
                overlaps++;
            }
            else if (InBetween(elf2Section.First(), elf1Section.First(), elf1Section.Skip(1).First()) || InBetween(elf2Section.Skip(1).First(), elf1Section.First(), elf1Section.Skip(1).First()))
            {
                overlaps++;
            }
        }

        Console.WriteLine(overlaps);
    }

    private static bool InBetween(int a, int lower, int upper)
    {
        return a >= lower && a <= upper;
    }
}