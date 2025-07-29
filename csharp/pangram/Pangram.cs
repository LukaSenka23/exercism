using Xunit.Internal;

public static class Pangram
{
    public static bool IsPangram(string input)
    { 
        var letters = new HashSet<char>();
        if (string.IsNullOrEmpty(input))
            return false;
        input = input.ToLower();

        foreach (char c in input.ToLower())
        {
            if (char.IsLetter(c))
                letters.Add(c);
        }

        return letters.Count == 26;
    }
}
