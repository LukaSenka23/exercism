public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        var result = new List<char>();
        foreach (var c in plainValue.ToLower())
        {
            if (char.IsLetter(c))
            {
                var mapped = (char)('z' - (c - 'a'));
                result.Add(mapped);
            }
            else if (char.IsDigit(c))
            {
                result.Add(c);
            }
        }

        var grouped = new List<string>();
        for (int i = 0; i < result.Count; i += 5)
        {
            grouped.Add(new string(result.Skip(i).Take(5).ToArray()));
        }

        return string.Join(" ", grouped);
    }

    public static string Decode(string encodedValue)
    {
        var result = new List<char>();
        foreach (var c in encodedValue)
        {
            if (char.IsLetter(c))
            {
                var lower = char.ToLower(c);
                var mapped = (char)('z' - (lower - 'a'));
                result.Add(mapped);
            }
            else if (char.IsDigit(c))
            {
                result.Add(c);
            }
        }

        return new string(result.ToArray());
    }
}
