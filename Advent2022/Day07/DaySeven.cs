namespace Advent2022.Day07
{
    public class DaySeven
    {

        public static long GetTotalSizeOfDirectories(Directory dir, int atMost)
        {
            long totalSize = 0;
            foreach (var child in dir.Children)
            {
                totalSize += GetTotalSizeOfDirectories(child, atMost);
            }

            return dir.TotalSize <= atMost ? dir.TotalSize + totalSize : totalSize;
        }

        public static Directory ParseCommands(string[] data)
        {
            var start = new Directory()
            {
                Name = data[0].Split(" ")[2]
            };

            Directory currentDirectory = start;
            for (var idx = 1; idx < data.Length; idx++)
            {
                var input = data[idx].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "$")
                {
                    switch (input[1])
                    {
                        case "cd":
                            if (input[2] == "..")
                            {
                                currentDirectory = currentDirectory.Parent;
                            }
                            else
                            {
                                currentDirectory = currentDirectory.Children.First(d => d.Name.Equals(input[2]));
                            }
                            break;

                        default:

                            break;
                    }
                }
                else
                {
                    if (input[0] == "dir")
                    {
                        var newDir = new Directory()
                        {
                            Name = input[1],
                            Parent = currentDirectory,
                        };
                        currentDirectory.Children.Add(newDir);
                    }
                    else
                    {
                        currentDirectory.Files.Add(input[1], int.Parse(input[0]));
                    }
                }
            }
            return start;
        }
        public static void ProblemOne()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day07\\ProblemOne.txt");

            var start = ParseCommands(data);
            var totalSize = GetTotalSizeOfDirectories(start, 100000);
            Console.WriteLine($"Problem 7.1: {totalSize}");
            Console.WriteLine("-----------------------------");
        }

        public static Directory FindDirectoryToDelete(Directory dir, long minSize)
        {
            Directory match = null;
            foreach (var child in dir.Children)
            {
                var found = FindDirectoryToDelete(child, minSize);

                if (match == null)
                {
                    match = found;
                }
                else if (found != null && match.TotalSize > found.TotalSize)
                {
                    match = found;
                }
            }

            if (match == null && dir.TotalSize >= minSize
                || match?.TotalSize >= dir.TotalSize)
            {
                match = dir;
            }

            return match;
        }

        public static void ProblemTwo()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day07\\ProblemTwo.txt");

            var start = ParseCommands(data);
            var minSpaceNeeded = 30000000 - (70000000 - start.TotalSize);
            var matchingDir = FindDirectoryToDelete(start, minSpaceNeeded);
            Console.WriteLine($"Problem 7.2: {matchingDir.TotalSize}");
            Console.WriteLine("-----------------------------");
        }
    }
}
