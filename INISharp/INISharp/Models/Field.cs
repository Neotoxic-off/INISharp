namespace Models
{
    public class Field
    {
        public string? Line { get; set; }
        public Kinds.Kind Kind { get; set; }
        public Selector Selector { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }

        public Field(string Line)
        {
            this.Line = Line;
            this.Kind = Detect();
            this.Key = ExtractKey();
            this.Value = ExtractValue();
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
                    Selector = selector;
                    return (selector.Kind);
                }
            }

            return (Kinds.Kind.Property);
        }

        private string? ExtractKey()
        {
            Dictionary<Kinds.Kind, Func<string?>> Bind = new Dictionary<Kinds.Kind, Func<string?>>()
            {
                { Kinds.Kind.Property, ExtractKeyProperty },
                { Kinds.Kind.Section, ExtractKeySection },
                { Kinds.Kind.Empty, ExtractKeyEmpty },
                { Kinds.Kind.Comment, ExtractKeyComment }
            };

            return (Bind[Kind]());
        }

        private string? ExtractValue()
        {
            Dictionary<Kinds.Kind, Func<string?>> Bind = new Dictionary<Kinds.Kind, Func<string?>>()
            {
                { Kinds.Kind.Property, ExtractValueProperty },
                { Kinds.Kind.Section, ExtractValueSection },
                { Kinds.Kind.Empty, ExtractValueEmpty },
                { Kinds.Kind.Comment, ExtractValueComment }
            };

            return (Bind[Kind]());
        }

        private string? ExtractKeyEmpty()
        {
            return (null);
        }

        private string? ExtractValueEmpty()
        {
            return (null);
        }

        private string? ExtractKeyProperty()
        {
            return (Line?.Split('=')[0].Trim());
        }

        private string? ExtractValueProperty()
        {
            return (Line?.Split('=')[1].Trim());
        }

        private string? ExtractKeySection()
        {
            return (null);
        }

        private string? ExtractValueSection()
        {
            return (Line?[1..^1]);
        }

        private string? ExtractKeyComment()
        {
            return (null);
        }

        private string? ExtractValueComment()
        {
            return (Line?.Remove(0));
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

