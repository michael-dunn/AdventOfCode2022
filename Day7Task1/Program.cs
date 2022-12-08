using System.IO.Enumeration;

public class Program
{
    public static void Main(string[] args)
    {
        var fileData = File.ReadAllText("input.txt").Split(Environment.NewLine);

        var computer = new AdventDirectory("root");
        AdventDirectory currentDirectory = computer;
        List<AdventDirectory> prev = new List<AdventDirectory>();
        for (int i = 0; i < fileData.Length; i++)
        {
            var lineParts = fileData[i].Split(' ');
            if (lineParts.FirstOrDefault() == "$") // command
            {
                if (lineParts[1] == "cd") // change directory
                {
                    switch (lineParts[2])
                    {
                        case ".."://go up
                            currentDirectory = prev.Last();
                            prev.Remove(currentDirectory);
                            break;
                        default:// go to
                            prev.Add(currentDirectory);
                            if (!currentDirectory.Directories.Any(d => d.Name == lineParts[2]))
                                currentDirectory.Directories.Add(new AdventDirectory(lineParts[2]));

                            currentDirectory = currentDirectory.Directories.First(d => d.Name == lineParts[2]);
                            break;
                    }
                    //currentDirectory.Directories.Add(new AdventDirectory(new string(line.Skip(line.IndexOf("cd") + 3).ToArray())));
                }
                else if (lineParts[1] == "ls")
                {
                    while (StillListingFiles(fileData.Skip(++i).FirstOrDefault()))
                    {
                        lineParts = fileData[i].Split(' ');
                        switch (lineParts[0])
                        {
                            case "dir":
                                currentDirectory.Directories.Add(new AdventDirectory(lineParts[1]));
                                break;
                            default:
                                currentDirectory.Files.Add(new AdventFile(lineParts[1], int.Parse(lineParts[0])));
                                break;
                        }
                    }
                    i--;
                }
            }
        }

        int total = GetSumOfAllDirectories(computer, 100000);



        Console.WriteLine(total);
    }
    public static int GetSumOfAllDirectories(AdventDirectory directory, int maxSize)
    {
        int total = 0;
        if (directory.GetSize() <= maxSize)
            total += directory.GetSize();

        return total + directory.Directories.Sum(d => GetSumOfAllDirectories(d, maxSize));
    }
    public static bool StillListingFiles(string? line)
    {
        return line is not null && !line.StartsWith("$");
    }

    public class AdventDirectory
    {
        public string Name { get; set; }
        public List<AdventFile> Files { get; set; }
        public List<AdventDirectory> Directories { get; set; }

        public AdventDirectory(string name)
        {
            Name = name;
            Files = new List<AdventFile>();
            Directories = new List<AdventDirectory>();
        }

        private int size = -1;
        public int GetSize()
        {
            if (size != -1)
                return size;
            return size = Files.Sum(f => f.Size) + Directories.Sum(d => d.GetSize());
        }
    }

    public class AdventFile
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public AdventFile(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}