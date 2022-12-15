namespace Advent2022.Day10
{
    public class DayTen
    {
        public static void ProblemOne()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day10\\ProblemOne.txt");
            var cycle = 0;
            var x = 1;
            var signalStrengths = new List<int>();
            foreach (var instruction in data)
            {
                var totalCycles = 2;
                var splitInstr = instruction.Split(' ');
                var xOp = splitInstr.Length > 1 ? int.Parse(splitInstr[1]) : 0;
                switch (splitInstr[0])
                {
                    case "noop":
                        totalCycles = 1;
                        break;

                    case "addx":
                        break;

                    default:
                        break;

                }
                for (var idx = 0; idx < totalCycles; idx++)
                {
                    cycle++;
                    if (cycle == 20
                        || cycle == 60
                        || cycle == 100
                        || cycle == 140
                        || cycle == 180
                        || cycle == 220)
                    {
                        signalStrengths.Add(cycle * x);
                    }
                }
                x += xOp;
            }
            var total = signalStrengths.Sum();
            Console.WriteLine($"Problem 10.1: {total}");
            Console.WriteLine("-----------------------------");
        }

        public static void ProblemTwo()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day10\\ProblemTwo.txt");


            Console.WriteLine($"Problem 10.2: {0}");
            Console.WriteLine("-----------------------------");
        }
    }
}
