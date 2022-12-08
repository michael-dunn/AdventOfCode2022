public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt");

        var transmissionMarker = new List<char>();
        int position = 0;
        while (transmissionMarker.Count != 4 && position != fileData.Length)
        {
            if (transmissionMarker.FirstOrDefault() != fileData[position])
            {
                if (transmissionMarker.Skip(1).FirstOrDefault() != fileData[position])
                {
                    if (transmissionMarker.Skip(2).FirstOrDefault() != fileData[position])
                    {
                        transmissionMarker.Add(fileData[position]);
                    }
                    else
                    {
                        transmissionMarker = transmissionMarker.Skip(3).ToList();
                        transmissionMarker.Add(fileData[position]);
                    }
                }
                else
                {
                    transmissionMarker = transmissionMarker.Skip(2).ToList();
                    transmissionMarker.Add(fileData[position]);
                }
            }
            else
            {
                transmissionMarker = transmissionMarker.Skip(1).ToList();
                transmissionMarker.Add(fileData[position]);
            }

            position++;
        }

        Console.WriteLine(position);
    }
}