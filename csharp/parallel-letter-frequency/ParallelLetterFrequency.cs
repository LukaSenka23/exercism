using System.Globalization;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        var result = new Dictionary<char, int>();
        foreach (var text in texts)
        {
            foreach (var ch in text)
            {
                if (char.IsLetter(ch))
                {
                    char letter = char.ToLower(ch);
                    
                    if (result.ContainsKey(letter))
                        result[letter]++;
                    else
                        result[letter] = 1;
                }
            }
        }

        return result;
    }
}