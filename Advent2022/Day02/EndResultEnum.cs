namespace Advent2022.Day02
{
    public class EndResultEnum
    {
        public static EndResultEnum Lose = new("X", 0, "Lose");
        public static EndResultEnum Draw = new("Y", 3, "Draw");
        public static EndResultEnum Win = new("Z", 6, "Win");

        public EndResultEnum(string code, int score, string name)
        {
            (Code, Score, Name) = (code, score, name);
        }

        public string Code { get; set; }

        public string Name { get; set; }


        public int Score { get; set; }

        public static EndResultEnum GetEnum(string code)
        {
            return ToList().First(p => p.Code.Equals(code));
        }

        public static List<EndResultEnum> ToList()
        {
            return new List<EndResultEnum> { Lose, Draw, Win };
        }
    }
}
