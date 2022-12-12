namespace Advent2022.Day09
{
    public class DayNine
    {
        public static void ProblemOne()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day09\\Sample.txt");
            var head = new RopePoint { X = 0, Y = 0 };
            var tail = new RopePoint { X = 0, Y = 0 };
            var visitedPoints = new HashSet<string>();
            foreach (var movement in data)
            {
                var direction = movement[0];
                var spaces = int.Parse(movement.Substring(1).Trim());
                int moveY = 0;
                int moveX = 0;
                switch (direction)
                {
                    case 'U':
                        moveY = 1;
                        break;

                    case 'D':
                        moveY = -1;
                        break;

                    case 'L':
                        moveX = -1;
                        break;

                    case 'R':
                        moveX = 1;
                        break;
                }

                for (int i = 0; i < spaces; i++)
                {
                    head.X += moveX;
                    head.Y += moveY;

                    // Head has moved more than one block away from the Tail
                    if (head.X - tail.X > 1
                        || head.Y - tail.Y > 1)
                    {
                        if (head.X == tail.X)
                        {
                            tail.Y += moveY;
                        }
                        else if (head.Y == tail.Y)
                        {
                            tail.X += moveX;
                        }
                        // Move on the diagonal
                        else
                        {
                            switch (direction)
                            {
                                case 'U':
                                case 'D':
                                    var diagX = head.X - tail.X;
                                    tail.X += diagX;
                                    tail.Y += moveY;
                                    break;

                                case 'L':
                                case 'R':
                                    var diagY = head.Y - tail.Y;
                                    tail.Y += diagY;
                                    tail.X += moveX;
                                    break;
                            }
                        }
                    }
                    visitedPoints.Add($"{tail.X}-{tail.Y}");
                }
            }
            Console.WriteLine($"Problem 9.1: {visitedPoints.Count}");
            Console.WriteLine("-----------------------------");
        }


        public static void ProblemTwo()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day09\\Sample.txt");

            Console.WriteLine($"Problem 9.2: {0}");
            Console.WriteLine("-----------------------------");
        }
    }
}
