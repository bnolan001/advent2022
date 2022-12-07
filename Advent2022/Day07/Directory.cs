namespace Advent2022.Day07
{
    public class Directory
    {
        public Directory Parent { get; set; }

        public string Name { get; set; }

        public Dictionary<string, int> Files { get; set; }

        public List<Directory> Children { get; set; }

        public long TotalSize => Files.Sum(f => f.Value) + Children.Sum(c => c.TotalSize);

        public Directory()
        {
            Files = new Dictionary<string, int>();
            Children = new List<Directory>();
        }
    }
}
