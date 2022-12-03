namespace Advent2022.Day02;

public class PlayEnum
{
    public static PlayEnum TheirRock = new("A", 1, 1, "Rock");
    public static PlayEnum TheirPaper = new("B", 2, 2, "Paper");
    public static PlayEnum TheirScissors = new("C", 3, 3, "Scissors");
    public static PlayEnum MyRock = new("X", 1, 1, "Rock");
    public static PlayEnum MyPaper = new("Y", 2, 2, "Paper");
    public static PlayEnum MyScissors = new("Z", 3, 3, "Scissors");

    public PlayEnum(string code, int value, int score, string name)
    {
        (Code, Value, Score, Name) = (code, value, score, name);
    }

    public string Code { get; set; }

    public string Name { get; set; }

    public int Value { get; set; }

    public int Score { get; set; }

    public static PlayEnum GetEnum(string code)
    {
        return ToList().First(p => p.Code.Equals(code));
    }

    public static List<PlayEnum> ToList()
    {
        return new List<PlayEnum> { TheirRock, TheirPaper, TheirScissors, MyRock, MyPaper, MyScissors };
    }
}