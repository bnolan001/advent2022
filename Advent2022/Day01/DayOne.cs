namespace Advent2022.Day01;

public static class DayOne
{
    public static void ProblemOne()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day01\\ProblemOne.txt");
        long elfTotalCalories = 0;
        var elfId = 1;
        var maxCalories = new KeyValuePair<int, long>(elfId, elfTotalCalories);
        foreach (var line in data)
            if (string.IsNullOrEmpty(line.Trim()))
            {
                if (maxCalories.Value < elfTotalCalories)
                    maxCalories = new KeyValuePair<int, long>(elfId, elfTotalCalories);
                elfId++;
                elfTotalCalories = 0;
            }
            else
            {
                elfTotalCalories += int.Parse(line);
            }

        if (elfTotalCalories > 0)
        {
            if (maxCalories.Value < elfTotalCalories)
                maxCalories = new KeyValuePair<int, long>(elfId, elfTotalCalories);
            elfId++;
            elfTotalCalories = 0;
        }

        Console.WriteLine($"Problem 1.1: {maxCalories.Key}-{maxCalories.Value}");
        Console.WriteLine("-----------------------------");
    }

    public static void ProblemTwo()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day01\\ProblemTwo.txt");
        long elfTotalCalories = 0;
        var elfId = 1;
        var maxCalories = new List<long> { 0, 0, 0 };
        foreach (var line in data)
            if (string.IsNullOrEmpty(line.Trim()))
            {
                if (maxCalories[2] < elfTotalCalories)
                {
                    maxCalories[2] = elfTotalCalories;
                    maxCalories.Sort();
                    maxCalories.Reverse();
                }

                elfTotalCalories = 0;
            }
            else
            {
                elfTotalCalories += int.Parse(line);
            }

        if (maxCalories[2] < elfTotalCalories) maxCalories[2] = elfTotalCalories;

        var total = maxCalories[0] + maxCalories[1] + maxCalories[2];
        Console.WriteLine($"Problem 1.2: {total}");
        Console.WriteLine("-----------------------------");
    }
}