namespace Advent2022.Day02;

public static class DayTwo
{
    private static int FindWinner(PlayEnum them, PlayEnum me)
    {
        if (me.Value == them.Value) return 3;

        if (me.Value == PlayEnum.A.Value && them.Value == PlayEnum.C.Value) return 6;

        if (me.Value == PlayEnum.B.Value && them.Value == PlayEnum.A.Value) return 6;

        if (me.Value == PlayEnum.C.Value && them.Value == PlayEnum.B.Value) return 6;

        return 0;
    }

    public static int GetScore(int whoWon, PlayEnum me)
    {
        return whoWon + me.Score;
    }

    public static void ProblemOne()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day02\\DayTwoProblemOne.txt");
        var score = 0;

        foreach (var line in data)
        {
            var plays = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var them = PlayEnum.GetEnum(plays[0]);
            var me = PlayEnum.GetEnum(plays[1]);
            var whoWon = FindWinner(them, me);
            var gameScore = GetScore(whoWon, me);

            score += gameScore;
        }


        Console.WriteLine($"Problem 2.1: {score}");
        Console.WriteLine("-----------------------------");
    }

    public static void ProblemTwo()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day02\\DayTwoProblemTwo.txt");
        var score = 0;

        foreach (var line in data)
        {
            var plays = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var them = PlayEnum.GetEnum(plays[0]);
            var me = PlayEnum.GetEnum(plays[1]);
            var whoWon = FindWinner(them, me);


            score += whoWon;
        }


        Console.WriteLine($"Problem 2.2: {score}");
        Console.WriteLine("-----------------------------");
    }
}