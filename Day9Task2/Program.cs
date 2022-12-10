public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine).Select(a => a.Split(' '));

        (int x, int y) head = (0, 0);
        List<(int x, int y)> tails = new List<(int, int)>()
        {
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
            (0, 0),
        };

        HashSet<(int, int)> result = new HashSet<(int, int)>();

        result.Add(tails[8]);

        foreach (var action in fileData)
        {
            int movements = int.Parse(action[1]);
            for (int i = 0; i < movements; i++)
            {
                switch (action[0])
                {
                    case "R":
                        head = (head.x + 1, head.y);
                        break;
                    case "U":
                        head = (head.x, head.y + 1);
                        break;
                    case "L":
                        head = (head.x - 1, head.y);
                        break;
                    case "D":
                        head = (head.x, head.y - 1);
                        break;
                }

                if (IsTailTouchingHead(head, tails[0]))
                    continue;

                tails[0] = GetNewTailPosition(head, tails[0]);

                for (int j = 1; j < tails.Count; j++)
                {
                    if (IsTailTouchingHead(tails[j - 1], tails[j]))
                        continue;

                    tails[j] = GetNewTailPosition(tails[j - 1], tails[j]);
                }

                result.Add(tails[8]);
            }
        }

        Console.WriteLine(result.Count);
    }

    public static bool IsTailTouchingHead((int x, int y) head, (int x, int y) tail)
    {
        return Math.Abs(head.x - tail.x) < 2 && Math.Abs(head.y - tail.y) < 2;
    }

    public static (int, int) GetNewTailPosition((int x, int y) head, (int x, int y) tail)
    {
        if (head.x == tail.x)
            return (tail.x, tail.y + ((head.y - tail.y) > 0 ? 1 : -1));
        if (head.y == tail.y)
            return (tail.x + ((head.x - tail.x) > 0 ? 1 : -1), tail.y);

        return (tail.x + ((head.x - tail.x) > 0 ? 1 : -1), tail.y + ((head.y - tail.y) > 0 ? 1 : -1));
    }
}