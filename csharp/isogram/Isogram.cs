public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var seen = new HashSet<char>();
        
        if (string.IsNullOrEmpty(word))
            return true;
        foreach (var c in word.ToLower())
        {
            if (!char.IsLetter(c)) continue;
            if (seen.Contains(c))
                return false;
            seen.Add(c);
        }
        return true;
    }
}
