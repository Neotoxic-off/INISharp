namespace INISharp;

public class Parser
{
    public List<Models.Field>? Parse(string[] lines)
    {
        List<Models.Field>? Fields = new List<Models.Field>();

        foreach (string line in lines)
        {
            Fields.Add(new Models.Field(line));
        }

        return (Fields);
    }
}
