using System.Runtime.InteropServices.JavaScript;

public class Robot
{
    private string _name;
    private static readonly Random random = new ();
    private static readonly HashSet<string> usedNames = new ();
    
    public string Name => _name;

    public Robot() => _name = GenerateName();

    public void Reset() => _name = GenerateName();

    private string GenerateName()
    {
        string candidate;
        do
        {
            var letters = $"{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}";
            var digits = random.Next(0, 1000).ToString("D3");
            candidate = $"{letters}{digits}";
        } while (!usedNames.Add(candidate));

        
        return candidate;
    }
}