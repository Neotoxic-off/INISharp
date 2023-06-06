namespace Models
{
    public class Selector
    {
        public string? Start { get; set; }
        public string? End { get; set; }
        public Kinds.Kind Kind { get; set; }

        public Selector(string? Start, string? End, Kinds.Kind Kind)
        {
            this.Start = Start;
            this.End = End;
            this.Kind = Kind;
        }
    }
}