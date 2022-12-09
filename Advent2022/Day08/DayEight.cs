namespace Advent2022.Day08
{
    public class DayEight
    {
        public static void ProblemOne()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day08\\ProblemOne.txt");
            var hiddenTrees = new List<List<int>>();

            // Check horizontal
            for (var rowIdx = 0; rowIdx < data.Length; rowIdx++)
            {
                hiddenTrees.Add(Enumerable.Repeat(0, data[rowIdx].Length).ToList());
                var maxHeight = -1;
                for (int colIdx = 0; colIdx < data[rowIdx].Length; colIdx++)
                {
                    var treeHeight = int.Parse(data[rowIdx][colIdx].ToString());
                    if (treeHeight > maxHeight)
                    {
                        hiddenTrees[rowIdx][colIdx] = 1;
                        maxHeight = treeHeight;
                    }
                }
                maxHeight = -1;
                for (int colIdx = data[rowIdx].Length - 1; colIdx > -1; colIdx--)
                {
                    var treeHeight = int.Parse(data[rowIdx][colIdx].ToString());
                    if (treeHeight > maxHeight)
                    {
                        hiddenTrees[rowIdx][colIdx] = 1;
                        maxHeight = treeHeight;
                    }

                }
            }

            // Check Vertical
            for (var colIdx = 0; colIdx < data[0].Length; colIdx++)
            {
                var maxHeight = -1;
                for (int rowIdx = 0; rowIdx < data.Length; rowIdx++)
                {
                    var treeHeight = int.Parse(data[rowIdx][colIdx].ToString());
                    if (treeHeight > maxHeight)
                    {
                        hiddenTrees[rowIdx][colIdx] = 1;
                        maxHeight = treeHeight;
                    }
                }
                maxHeight = -1;
                for (int rowIdx = data.Length - 1; rowIdx > -1; rowIdx--)
                {
                    var treeHeight = int.Parse(data[rowIdx][colIdx].ToString());
                    if (treeHeight > maxHeight)
                    {
                        hiddenTrees[rowIdx][colIdx] = 1;
                        maxHeight = treeHeight;
                    }
                }
            }

            var hidden = 0;
            foreach (var line in hiddenTrees)
            {
                foreach (var tree in line)
                {
                    if (tree > 0)
                    {
                        hidden++;
                    }
                }
            }

            var totalHiddenTrees = hiddenTrees.Sum(x => x.Sum(y => y));

            Console.WriteLine($"Problem 8.1: {totalHiddenTrees}");
            Console.WriteLine("-----------------------------");
        }


        public static void ProblemTwo()
        {
            Console.WriteLine("-----------------------------");
            var data = File.ReadAllLines("Day08\\ProblemTwo.txt");
            var trees = new List<List<int>>();
            // build a numerical forest
            foreach (var line in data)
            {
                trees.Add(new List<int>());
                for (var idx = 0; idx < line.Length; idx++)
                {
                    var tree = int.Parse(line[idx].ToString());
                    trees[trees.Count - 1].Add(tree);
                }
            }

            var maxViewable = 0;
            // Ignore the outside trees
            for (var rowIdx = 1; rowIdx < trees.Count - 1; rowIdx++)
            {
                for (var colIdx = 1; colIdx < trees[rowIdx].Count - 1; colIdx++)
                {
                    var viewableSouth = 1;
                    var first = true;
                    for (var x = rowIdx + 1; x < trees.Count(); x++)
                    {
                        if (trees[rowIdx][colIdx] > trees[x][colIdx])
                        {
                            if (!first) viewableSouth++;
                            first = false;
                        }
                        else if (!first && trees[rowIdx][colIdx] == trees[x][colIdx])
                        {
                            viewableSouth++;
                            break;
                        }
                        else
                        {
                            if (!first) viewableSouth++;
                            break;
                        }
                    }
                    var viewableNorth = 1;
                    first = true;
                    for (var x = rowIdx - 1; x > -1; x--)
                    {
                        if (trees[rowIdx][colIdx] > trees[x][colIdx])
                        {
                            if (!first) viewableNorth++;
                            first = false;
                        }
                        else if (!first && trees[rowIdx][colIdx] == trees[x][colIdx])
                        {
                            viewableNorth++;
                            break;
                        }
                        else
                        {
                            if (!first) viewableNorth++;
                            break;
                        }
                    }
                    var viewableEast = 1;
                    first = true;
                    for (var x = colIdx + 1; x < trees[0].Count(); x++)
                    {
                        if (trees[rowIdx][colIdx] > trees[rowIdx][x])
                        {
                            if (!first) viewableEast++;
                            first = false;
                        }
                        else if (!first && trees[rowIdx][colIdx] == trees[rowIdx][x])
                        {
                            viewableEast++;
                            break;
                        }
                        else
                        {
                            if (!first) viewableEast++;
                            break;
                        }
                    }
                    var viewableWest = 1;
                    first = true;
                    for (var x = colIdx - 1; x > -1; x--)
                    {
                        if (trees[rowIdx][colIdx] > trees[rowIdx][x])
                        {
                            if (!first) viewableWest++;
                            first = false;
                        }
                        else if (!first && trees[rowIdx][colIdx] == trees[rowIdx][x])
                        {
                            viewableWest++;
                            break;
                        }
                        else
                        {
                            if (!first) viewableWest++;
                            break;
                        }
                    }
                    var totalViewable = viewableEast * viewableNorth * viewableSouth * viewableWest;
                    if (maxViewable < totalViewable)
                    {
                        maxViewable = totalViewable;
                    }
                }
            }
            Console.WriteLine($"Problem 8.2: {maxViewable}");
            Console.WriteLine("-----------------------------");
        }
    }
}
