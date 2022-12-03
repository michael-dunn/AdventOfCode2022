public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var outcomes = new List<int>();
        foreach (var match in fileData)
        {
            var playerChoices = match.Split(' ');

            var score = 0;

            switch (playerChoices[1])
            {
                case "X":
                    score = 1;
                    break;
                case "Y":
                    score = 2;
                    break;
                case "Z":
                    score = 3;
                    break;
                default:
                    throw new Exception("player choice not found");
            }

            switch ((playerChoices[0], playerChoices[1]))
            {
                //A,X = Rock
                //B,Y = Paper
                //C,Z = Scissors

                case ("A", "Y"):
                case ("B", "Z"):
                case ("C", "X"):
                    score += 6;
                    break;
                case ("A", "X"):
                case ("B", "Y"):
                case ("C", "Z"):
                    score += 3;
                    break;
                default:
                    break;
            }

            outcomes.Add(score);
        }

        Console.WriteLine(outcomes.Sum());
    }
}