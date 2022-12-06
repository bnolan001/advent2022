namespace Advent2022.Day02;

public static class DayTwo
{
    private static int FindWinner(PlayEnum them, PlayEnum me)
    {
        if (me.Value == them.Value) return 3;

        if (me.Value == PlayEnum.TheirRock.Value && them.Value == PlayEnum.TheirScissors.Value) return 6;

        if (me.Value == PlayEnum.TheirPaper.Value && them.Value == PlayEnum.TheirRock.Value) return 6;

        if (me.Value == PlayEnum.TheirScissors.Value && them.Value == PlayEnum.TheirPaper.Value) return 6;

        return 0;
    }

    public static int GetScore(int whoWon, PlayEnum me)
    {
        return whoWon + me.Score;
    }

    public static void ProblemOne()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day02\\ProblemOne.txt");
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

    private static int GetResultScore(PlayEnum theirPlay, EndResultEnum howEnds)
    {
        if (howEnds == EndResultEnum.Lose)
        {
            switch (theirPlay.Name)
            {
                case "Rock":
                    return PlayEnum.TheirScissors.Score;
                case "Paper":
                    return PlayEnum.TheirRock.Score;
                case "Scissors":
                    return PlayEnum.TheirPaper.Score;
            }
        }

        if (howEnds == EndResultEnum.Draw)
        {
            switch (theirPlay.Name)
            {
                case "Rock":
                    return PlayEnum.TheirRock.Score;
                case "Paper":
                    return PlayEnum.TheirPaper.Score;
                case "Scissors":
                    return PlayEnum.TheirScissors.Score;
            }
        }

        // Win
        switch (theirPlay.Name)
        {
            case "Rock":
                return PlayEnum.TheirPaper.Score;
            case "Paper":
                return PlayEnum.TheirScissors.Score;
            case "Scissors":
                return PlayEnum.TheirRock.Score;
        }
        throw new Exception();
    }

    public static void ProblemTwo()
    {
        Console.WriteLine("-----------------------------");
        var data = File.ReadAllLines("Day02\\ProblemTwo.txt");
        var score = 0;

        foreach (var line in data)
        {
            var plays = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var them = PlayEnum.GetEnum(plays[0]);
            var endAs = EndResultEnum.GetEnum(plays[1]);
            var playScore = GetResultScore(them, endAs);


            score += playScore + endAs.Score;
        }


        Console.WriteLine($"Problem 2.2: {score}");
        Console.WriteLine("-----------------------------");
    }
}