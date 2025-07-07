public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var counts = new Dictionary<char, int>()
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };
        foreach (char nucleo in sequence)
        {
            if (counts.ContainsKey(nucleo))
            {
                counts[nucleo]++;
            }
            else
            {
                throw new ArgumentException("$ Invalid nucleotide: {nucleo}");
            }

        }
        return counts;
    }
}