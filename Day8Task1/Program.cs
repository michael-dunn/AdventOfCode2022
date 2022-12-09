public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var treeGrid = fileData.Select(r => r.Select(t => t-48).ToList()).ToList();

        int visibleTrees = 0;

        visibleTrees += treeGrid.Count * 2;
        visibleTrees += treeGrid[0].Count * 2 - 4;

        for (int row = 1; row < treeGrid.Count-1; row++)
        {
            for (int column = 1; column < treeGrid[row].Count-1; column++)
            {
                if (GetVisibility(treeGrid, row, column))
                    visibleTrees++;
            }
        }

        Console.WriteLine(visibleTrees);
    }

    private static bool GetVisibility(List<List<int>> treeGrid, int row, int column)
    {
        //check left
        for (int i = column - 1; i >= 0; i--)
        {
            if (treeGrid[row][column] > treeGrid[row][i])
            {
                if (i == 0)
                {
                    return true;
                }
                continue;
            }
            //A tree is larger than it in that direction
            break;
        }
        //check up
        for (int i = row - 1; i >= 0; i--)
        {
            if (treeGrid[row][column] > treeGrid[i][column])
            {
                if (i == 0)
                {
                    return true;
                }
                continue;
            }
            //A tree is larger than it in that direction
            break;

        }
        //check right
        for (int i = column + 1; i < treeGrid[row].Count; i++)
        {
            if (treeGrid[row][column] > treeGrid[row][i])
            {
                if (i == treeGrid[row].Count-1)
                {
                    return true;
                }
                continue;
            }
            //A tree is larger than it in that direction
            break;
        }
        //check down
        for (int i = row + 1; i < treeGrid.Count; i++)
        {
            if (treeGrid[row][column] > treeGrid[i][column])
            {
                if (i == treeGrid.Count-1)
                {
                    return true;
                }
                continue;
            }
            //A tree is larger than it in that direction
            break;
        }

        return false;
    }
}