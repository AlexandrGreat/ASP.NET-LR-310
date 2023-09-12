namespace LR2
{
    public class Student
    {
        public string Name { get; set; } = "";
        public int Group { get; set; }
        public List<string> ProgramLanguages { get; set; } = new();
        public Study? Study { get; set; }
    }

    public class Study
    {
        public string University { get; set; } = "";
        public string Country { get; set; } = "";
    }
}
