using System;
using System.ComponentModel;
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var outcomes = new List<int>();
        foreach (var match in fileData)
        {
            var playerChoices = match.Split(' ');

            var parsedChoices = ((Choice)Enum.Parse(typeof(Choice), playerChoices[0]), (Outcome)Enum.Parse(typeof(Outcome), playerChoices[1]));

            Choice choice;

            switch (parsedChoices)
            {
                //Lose
                case (_, Outcome.X):
                    choice = (Choice)Mod((int)(parsedChoices.Item1- 1), 3);
                    break;
                //Draw
                case (_, Outcome.Y):
                    choice = parsedChoices.Item1;
                    break;
                //Win
                case (_, Outcome.Z):
                    choice = (Choice)Mod((int)(parsedChoices.Item1 + 1), 3);
                    break;
                default:
                    throw new Exception("No outcome found");
            }

            outcomes.Add((int)choice + 1 + (int)parsedChoices.Item2);
        }

        Console.WriteLine(outcomes.Sum());
    }

    private static int Mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    public enum Choice
    {
        [Description("Rock")]
        A,
        [Description("Paper")]
        B,
        [Description("Scissors")]
        C
    }

    public enum Outcome
    {
        [Description("Lose")]
        X = 0,
        [Description("Draw")]
        Y = 3,
        [Description("Win")]
        Z = 6
    }



}

public static class EnumHelper
{
    public static string DescriptionAttr<T>(this T source)
    {
        FieldInfo fi = source.GetType().GetField(source.ToString());

        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0) return attributes[0].Description;
        else return source.ToString();
    }
}