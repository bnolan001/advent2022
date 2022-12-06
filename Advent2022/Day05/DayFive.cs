namespace Advent2022.Day05;

public static class DayFive
{
    public static void ProblemOne()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day05\\ProblemOne.txt");
        var idx = 0;
        long totalColumns = data[idx].Length / 4 + 1;
        var ship = new List<List<string>>(data[idx].Length / 4);
        for (var i = 0; i < totalColumns; i++) ship.Add(new List<string>());

        while (data[idx].Contains("["))
        {
            var text = data[idx];
            for (var splitIdx = 0; splitIdx < text.Length; splitIdx += 4)
            {
                var crate = text.Substring(splitIdx, 3).Trim();
                if (!string.IsNullOrWhiteSpace(crate)) ship[splitIdx / 4].Add(crate.Substring(1, 1));
            }

            idx++;
        }

        idx += 2; // skip the column numbers and empty line
        do
        {
            var splitLine = data[idx].Split(" ");
            var numToMove = int.Parse(splitLine[1]);
            var from = int.Parse(splitLine[3]) - 1;
            var to = int.Parse(splitLine[5]) - 1;
            for (var i = 0; i < numToMove; i++)
            {
                var val = ship[from][0];
                ship[from].RemoveAt(0);
                ship[to].Insert(0, val);
            }
        } while (++idx < data.Length);

        var topCrates = ship.Select(s => s.FirstOrDefault()).ToList();
        Console.WriteLine($"Problem 5.1: {string.Join("", topCrates)}");
        Console.WriteLine("-----------------------------");
    }

    public static void ProblemTwo()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day05\\ProblemTwo.txt");
        var idx = 0;
        long totalColumns = data[idx].Length / 4 + 1;
        var ship = new List<List<string>>(data[idx].Length / 4);
        for (var i = 0; i < totalColumns; i++) ship.Add(new List<string>());

        while (data[idx].Contains("["))
        {
            var text = data[idx];
            for (var splitIdx = 0; splitIdx < text.Length; splitIdx += 4)
            {
                var crate = text.Substring(splitIdx, 3).Trim();
                if (!string.IsNullOrWhiteSpace(crate)) ship[splitIdx / 4].Add(crate.Substring(1, 1));
            }

            idx++;
        }

        idx += 2; // skip the column numbers and empty line
        do
        {
            var splitLine = data[idx].Split(" ");
            var numToMove = int.Parse(splitLine[1]);
            var from = int.Parse(splitLine[3]) - 1;
            var to = int.Parse(splitLine[5]) - 1;
            for (var i = 0; i < numToMove; i++)
            {
                var cutIdx = numToMove - i - 1;
                var val = ship[from][cutIdx];
                ship[from].RemoveAt(cutIdx);
                ship[to].Insert(0, val);
            }
        } while (++idx < data.Length);

        var topCrates = ship.Select(s => s.FirstOrDefault()).ToList();
        Console.WriteLine($"Problem 5.2: {string.Join("", topCrates)}");
        Console.WriteLine("-----------------------------");
    }
}