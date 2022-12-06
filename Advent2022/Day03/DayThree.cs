namespace Advent2022.Day03;

public static class DayThree
{
    public static void ProblemOne()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day03\\DayThreeProblemOne.txt");
        int idx = 0;
        long total = 0;
        do
        {
            var left = data[idx].Substring(0, data[idx].Length / 2);
            var right = data[idx].Substring(data[idx].Length / 2);
            var shared = left.Where(l => right.Contains(l)).ToList();
            var singleChar = shared.First();
            var value = singleChar > 'Z' ? singleChar - 96 : singleChar - 38;
            total += value;
        } while (++idx < data.Length);


        Console.WriteLine($"Problem 3.1: {total}");
        Console.WriteLine("-----------------------------");
    }

    public static void ProblemTwo()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day03\\DayThreeProblemTwo.txt");



        Console.WriteLine($"Problem 3.2: ");
        Console.WriteLine("-----------------------------");
    }
}