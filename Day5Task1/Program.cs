using System.Reflection.Metadata.Ecma335;

public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine).ToList();

        var blankIndex = fileData.IndexOf("");

        var stacksData = fileData.Take(blankIndex - 1).ToList().Select(r => r.Replace("    ", " ").Split(' '));
        var instructionData = fileData.Skip(blankIndex + 1).Select(i => i.Split(' ').Where((x, i) => (i + 1) % 2 == 0).Select(a => int.Parse(a)).ToList()).ToList();

        var stacks = new List<Stack<string>>();

        var stackNumbers = fileData[blankIndex - 1].Split(' ');
        var numberOfStacks = int.Parse(stackNumbers[stackNumbers.Count() - 2]);
        for (int i = 0; i < numberOfStacks; i++)
        {
            stacks.Add(new Stack<string>());
        }

        foreach (var stack in stacksData.Reverse())
        {
            foreach (var (item, index) in stack.Select((item, index) => (item, index)))
            {
                if (item != "")
                    stacks[index].Push(item);
            }
        }

        foreach (var instruction in instructionData)
        {
            for (int i = 0; i < instruction[0]; i++)
            {
                stacks[instruction[2] - 1].Push(stacks[instruction[1] - 1].Pop());
            }
        }

        Console.WriteLine(string.Join(", ",stacks.Select(s => s.Peek())));
    }
}