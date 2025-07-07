public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var result = new Dictionary<string, int>();
        
        foreach (var entry in old)
        {
            var score = entry.Key;
            foreach (var letter in entry.Value)
            {
                result.Add(letter.ToLower(),score);
            }
        }

        return result;
    }
}