public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt");

        var transmissionMarker = new List<char>();
        int position = 0;
        while (transmissionMarker.Count != 14 && position != fileData.Length)
        {
            for (int i = 0; i < transmissionMarker.Count + 1; i++)
            {
                if (transmissionMarker.Skip(i).FirstOrDefault() != fileData[position])
                {
                    if (i == transmissionMarker.Count)
                    {
                        transmissionMarker.Add(fileData[position]);
                        break;
                    }
                }
                else
                {
                    transmissionMarker = transmissionMarker.Skip(i + 1).ToList();
                    transmissionMarker.Add(fileData[position]);
                    break;
                }
            }

            position++;
        }

        Console.WriteLine(position);
    }
}