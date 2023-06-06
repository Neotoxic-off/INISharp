# INISharp
⚙️ INI file parser for C#

## Usage
```CS
INISharp.Parser parser = new INISharp.Parser();

List<Models.Field> result = parser.Parse(
    File.ReadAllLines(
        "Example.ini"
    )
);

foreach (Models.Field field in result)
{
    Console.WriteLine($"[{field.Kind}] Key:{field.Key} => Value:{field.Value}");
}
```
