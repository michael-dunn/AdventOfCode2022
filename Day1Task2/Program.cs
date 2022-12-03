public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var elves = new List<int>();

        var position = 0;
        while (position <= fileData.Length)
        {
            var foodCarriedByElf = fileData.Skip(position).TakeWhile(f => !string.IsNullOrEmpty(f));

            position = position + foodCarriedByElf.Count() + 1;

            elves.Add(foodCarriedByElf.Sum(f => int.Parse(f)));
        }

        int numberOfElves = 3;
        var topElves = new int[numberOfElves];

        foreach (var elf in elves)
        {
            for (int i = 0; i < topElves.Length; i++)
            {
                if (elf > topElves[i])
                {
                    topElves = AddElfToTopElves(i, elf, topElves);
                    break;
                }
            }
        }

        Console.WriteLine(string.Join(", ", topElves));
        Console.WriteLine($"The top {numberOfElves} elves carry {topElves.Sum()} calories");
    }

    public static int[] AddElfToTopElves(int position, int elf, int[] topElves)
    {

        var elfToBeMoved = topElves[position];
        topElves[position] = elf;

        //If we are at the end
        if (position + 1 == topElves.Length)
        {
            return topElves;
        }
        return AddElfToTopElves(position + 1, elfToBeMoved, topElves);

    }
}