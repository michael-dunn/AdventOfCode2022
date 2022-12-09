public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var treeGrid = fileData.Select(r => r.Select(t => t - 48).ToList()).ToList();

        int bestScore = 0;

        for (int row = 1; row < treeGrid.Count - 1; row++)
        {
            for (int column = 1; column < treeGrid[row].Count - 1; column++)
            {
                var score = GetScenicScore(treeGrid, row, column);
                if (score > bestScore)
                    bestScore = score;
            }
        }

        Console.WriteLine(bestScore);
    }

    private static int GetScenicScore(List<List<int>> treeGrid, int row, int column)
    {
        int left, up, right, down;
        left = up = right = down = 1;

        //check left
        for (int i = column - 1; i >= 0; i--)
        {
            if (treeGrid[row][column] > treeGrid[row][i])
            {
                if (i == 0)
                {
                    left = column - i;
                }
                continue;
            }
            //A tree is larger than it in that direction
            left = column - i;
            break;
        }
        //check up
        for (int i = row - 1; i >= 0; i--)
        {
            if (treeGrid[row][column] > treeGrid[i][column])
            {
                if (i == 0)
                {
                    up = row - i;
                }
                continue;
            }
            //A tree is larger than it in that direction
            up = row - i;
            break;

        }
        //check right
        for (int i = column + 1; i < treeGrid[row].Count; i++)
        {
            if (treeGrid[row][column] > treeGrid[row][i])
            {
                if (i == treeGrid[row].Count - 1)
                {
                    right = i - column;
                }
                continue;
            }
            //A tree is larger than it in that direction
            right = i - column;
            break;
        }
        //check down
        for (int i = row + 1; i < treeGrid.Count; i++)
        {
            if (treeGrid[row][column] > treeGrid[i][column])
            {
                if (i == treeGrid.Count - 1)
                {
                    down = i - row;
                }
                continue;
            }
            //A tree is larger than it in that direction
            down = i - row;
            break;
        }

        return left * up * right * down;
    }
}