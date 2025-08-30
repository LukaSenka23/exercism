public static class ProteinTranslation
{
    private static Dictionary<string, string> condoMap = new()
    {
        { "AUG", "Methionine" },
        { "UUU", "Phenylalanine" },
        { "UUC", "Phenylalanine" },
        { "UUA", "Leucine" },
        { "UUG", "Leucine" },
        { "UCU", "Serine" },
        { "UCC", "Serine" },
        { "UCA", "Serine" },
        { "UCG", "Serine" },
        { "UAU", "Tyrosine" },
        { "UAC", "Tyrosine" },
        { "UGU", "Cysteine" },
        { "UGC", "Cysteine" },
        { "UGG", "Tryptophan" },
        { "UAA", "STOP" },
        { "UAG", "STOP" },
        { "UGA", "STOP" }
    };
    public static string[] Proteins(string strand)
    {
        var result = new List<string>();
        for (int i = 0; i < strand.Length; i += 3)
        {
            var condo = strand.Substring(i, 3);
            if (!condoMap.ContainsKey(condo))
                continue;
            var protein = condoMap[condo];
            if (protein == "STOP")
                break;
            result.Add(protein);
        }

        return result.ToArray();
    }
}