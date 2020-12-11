namespace Siram.Core
{
    public class Level
    {
        public string Hash { get; set; } = null!;
        public string? Source { get; set; } = null!;
        public Difficulty Difficulty { get; set; }
    }
}