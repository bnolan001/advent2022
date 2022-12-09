namespace Advent2022.Day03;

public class DayThree
{
    public static void ProblemOne()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day03\\ProblemOne.txt");
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
        var data = File.ReadAllLines("Day03\\ProblemTwo.txt");
        var group = new List<string>();
        int idx = 0;
        long total = 0;
        do
        {
            group.Add(data[idx]);
            if ((idx + 1) % 3 == 0 && idx > 0)
            {
                var singleChar = data[idx].Where(l => data[idx - 1].Contains(l)).Where(l => data[idx - 2].Contains(l)).First();
                var value = singleChar > 'Z' ? singleChar - 96 : singleChar - 38;
                total += value;
            }
        } while (++idx < data.Length);

        Console.WriteLine($"Problem 3.2: {total}");
        Console.WriteLine("-----------------------------");
    }
}