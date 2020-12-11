namespace Siram.Core
{
    public class User
    {
        public string ID { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Sirole Role { get; set; }
    }
}