namespace Advent2022.Day06;

public static class DaySix
{
    public static void ProblemOne()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllText("Day06\\ProblemOne.txt");
        var firstMarker = -1;
        for (var idx = 0; idx + 4 < data.Length; idx++)
        {
            var marker = data.Substring(idx, 4);
            var distinct = marker.Distinct().ToList();
            if (distinct.Count == 4)
            {
                firstMarker = idx + 4;
                break;
            }
        }

        Console.WriteLine($"Problem 6.1: {firstMarker}");
        Console.WriteLine("-----------------------------");
    }

    public static void ProblemTwo()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllText("Day06\\ProblemTwo.txt");
        var firstMarker = -1;
        for (var idx = 0; idx + 14 < data.Length; idx++)
        {
            var marker = data.Substring(idx, 14);
            var distinct = marker.Distinct().ToList();
            if (distinct.Count == 14)
            {
                firstMarker = idx + 14;
                break;
            }
        }

        Console.WriteLine($"Problem 6.2: {firstMarker}");
        Console.WriteLine("-----------------------------");
    }
}