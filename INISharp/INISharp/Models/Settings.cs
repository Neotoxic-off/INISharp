namespace Models
{
    public class Settings
    {
        public static List<Selector> Tags = new List<Selector>()
        {
            new Selector(";", null, Kinds.Kind.Comment),
            new Selector("#", null, Kinds.Kind.Comment),
            new Selector("//", null, Kinds.Kind.Comment),
            new Selector("[", "]", Kinds.Kind.Section)
        };
    }
}
