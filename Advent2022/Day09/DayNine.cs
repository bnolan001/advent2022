namespace Advent2022.Day09
{
    public class DayNine
    {
        public static void ProblemOne()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day09\\ProblemOne.txt");
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
                    if (Math.Abs(head.X - tail.X) > 1
                        || Math.Abs(head.Y - tail.Y) > 1)
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

        public static void PrintRope(List<RopePoint> knots)
        {
            var grid = new List<List<string>>();
            for (int row = 0; row < 80; row++)
            {
                grid.Add(Enumerable.Repeat(".", 80).ToList());
            }

            var idx = 0;
            foreach (var knot in knots)
            {
                grid[knot.Y + 40][knot.X + 40] = idx.ToString();
                idx++;
            }

            Console.WriteLine();
            grid.Reverse();
            foreach (var row in grid)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
        public static void ProblemTwo()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day09\\ProblemTwo.txt");
            var knots = new List<RopePoint>()
            { new RopePoint { X = 0, Y = 0 },
                new RopePoint { X = 0, Y = 0 },
                new RopePoint { X = 0, Y = 0 },
                new RopePoint { X = 0, Y = 0 },
                new RopePoint { X = 0, Y = 0 },
                new RopePoint { X = 0, Y = 0 },
                new RopePoint { X = 0, Y = 0 },
                new RopePoint { X = 0, Y = 0 },
                new RopePoint { X = 0, Y = 0 },
                new RopePoint { X = 0, Y = 0 } };

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
                char knotDirection = direction;
                for (int i = 0; i < spaces; i++)
                {
                    knots[0].X += moveX;
                    knots[0].Y += moveY;
                    for (var idx = 1; idx < knots.Count; idx++)
                    {
                        //Calculate distance to previous knot
                        var xDiff = knots[idx - 1].X - knots[idx].X;
                        var yDiff = knots[idx - 1].Y - knots[idx].Y;
                        if (Math.Abs(xDiff) > 1
                            || Math.Abs(yDiff) > 1)
                        {
                            if (Math.Abs(xDiff) + Math.Abs(yDiff) > 2)
                            {
                                knots[idx].X += xDiff > 0 ? 1 : -1;
                                knots[idx].Y += yDiff > 0 ? 1 : -1;
                            }
                            else
                            {
                                if (xDiff == 0)
                                {
                                    knots[idx].Y += (int)Math.Ceiling(yDiff / 2.0);
                                }
                                else
                                {
                                    knots[idx].X += (int)Math.Ceiling(xDiff / 2.0);
                                }
                            }
                        }
                    }
                    visitedPoints.Add($"{knots[knots.Count - 1].X}-{knots[knots.Count - 1].Y}");
                }
                //PrintRope(knots);
            }

            Console.WriteLine($"Problem 9.2: {visitedPoints.Count}");
            Console.WriteLine("-----------------------------");
        }
    }
}
