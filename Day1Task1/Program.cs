
public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var elves = new List<int>();

        var position = 0;
        while(position <= fileData.Length)
        {
            var foodCarriedByElf = fileData.Skip(position).TakeWhile(f => !string.IsNullOrEmpty(f));

            position = position + foodCarriedByElf.Count() + 1;

            elves.Add(foodCarriedByElf.Sum(f=>int.Parse(f)));
        }

        var maxCalories = elves.Max();
        var elfNumber = elves.IndexOf(maxCalories) + 1;

        Console.WriteLine($"The elf with the most calories is elf {elfNumber} with {maxCalories} calories");

        return;
    }
}