namespace Advent2022.Day04;

public class DayFour
{
    public static void ProblemOne()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day04\\ProblemOne.txt");
        int idx = 0;
        long total = 0;
        do
        {
            var assignments = data[idx].Split(",");
            var range = assignments[0].Split("-");
            var elfOne = new int[] { int.Parse(range[0]), int.Parse(range[1]) };
            range = assignments[1].Split("-");
            var elfTwo = new int[] { int.Parse(range[0]), int.Parse(range[1]) };
            if ((elfOne[0] >= elfTwo[0] && elfOne[1] <= elfTwo[1])
                || (elfTwo[0] >= elfOne[0] && elfTwo[1] <= elfOne[1]))
            {
                total++;
            }


        } while (++idx < data.Length);


        Console.WriteLine($"Problem 4.1: {total}");
        Console.WriteLine("-----------------------------");
    }

    public static void ProblemTwo()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day04\\ProblemTwo.txt");
        int idx = 0;
        long total = 0;
        do
        {
            var assignments = data[idx].Split(",");
            var range = assignments[0].Split("-");
            var elfOne = Enumerable.Range(int.Parse(range[0]), int.Parse(range[1]) - int.Parse(range[0]) + 1);
            range = assignments[1].Split("-");
            var elfTwo = Enumerable.Range(int.Parse(range[0]), int.Parse(range[1]) - int.Parse(range[0]) + 1);
            if (elfOne.Intersect(elfTwo).ToList().Count > 0)
            {
                total++;
            }


        } while (++idx < data.Length);
        Console.WriteLine($"Problem 4.2: {total}");
        Console.WriteLine("-----------------------------");
    }
}