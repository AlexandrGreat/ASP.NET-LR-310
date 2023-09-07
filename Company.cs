namespace LR1
{
    public class Company
    {
        public string Name { get; set; }
        public int Workers { get; set; }

        public string GetInfo() {
            return $"{Name}: {Workers} workers";
        }
    }
}
