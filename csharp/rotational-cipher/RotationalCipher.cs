using System.Text;

public static class RotationalCipher
{
    private static readonly List<char> lowercase = new List<char>("abcdefghijklmnopqrstuvwxyz"); 
    private static readonly List<char> uppercase = new List<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ"); 
    
    public static string Rotate(string text, int shiftKey)
    {
        var result = new StringBuilder();
        foreach (char ch in text)
        {
            if (lowercase.Contains(ch))
            {
                var index = lowercase.IndexOf(ch);
                var rotation = (index + shiftKey) % 26;
                var newLetter = lowercase[rotation];
                result.Append(newLetter);
            }
            else if (uppercase.Contains(ch))
            {
                var index = uppercase.IndexOf(ch);
                var rotation = (index + shiftKey) % 26;
                var newLetter = uppercase[rotation];
                result.Append(newLetter);
            }
            else
            {
                result.Append(ch);
            }
        }

        return result.ToString();

    }
}