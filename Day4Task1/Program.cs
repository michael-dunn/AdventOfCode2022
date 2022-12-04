public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var overlaps = 0;
        foreach(var elfPair in fileData)
        {
            var elfSections = elfPair.Split(',').Select(s => s.Split('-'));

            var elf1Section = elfSections.First();
            var elf2Section = elfSections.Skip(1).First();

            if (int.Parse(elf1Section.First()) >= int.Parse(elf2Section.First()) && int.Parse(elf1Section.Skip(1).First()) <= int.Parse(elf2Section.Skip(1).First()))
            {
                overlaps++;
            }
            else if (int.Parse(elf2Section.First()) >= int.Parse(elf1Section.First()) && int.Parse(elf2Section.Skip(1).First()) <= int.Parse(elf1Section.Skip(1).First()))
            {
                overlaps++;
            }
        }

        Console.WriteLine(overlaps);
    }
}