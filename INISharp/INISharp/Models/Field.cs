namespace Models
{
    public class Field
    {
        public string Line { get; set; }
        public Kinds.Kind Kind { get; set; }

        public Field(string Line)
        {
            this.Line = Line;
            this.Kind = Detect();
        }

        private bool IsEmpty()
        {
            return (String.IsNullOrEmpty(Line));
        }

        private Kinds.Kind Detect()
        {
            if (IsEmpty() == true)
            {
                return (Kinds.Kind.Empty);
            }

            foreach (Selector selector in Settings.Tags)
            {
                if (CheckStart(selector.Start) == true && CheckEnd(selector.End) == true)
                {
                    return (selector.Kind);
                }
            }

            return (Kinds.Kind.Property);
        }

        private bool CheckStart(string? Start)
        {
            if (String.IsNullOrEmpty(Start) == true)
                return (true);
            return (Line.StartsWith(Start));
        }

        private bool CheckEnd(string? End)
        {
            if (String.IsNullOrEmpty(End) == true)
                return (true);
            return (Line.EndsWith(End));
        }
    }
}

