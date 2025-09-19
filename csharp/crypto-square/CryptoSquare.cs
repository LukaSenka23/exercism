public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        string result = "";
        var trim =  plaintext.Trim();
        foreach (var ch in trim)
        {
            if (char.IsLetterOrDigit(ch))
            {
                result +=  char.ToLower(ch);
            }
        }
        return result;
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        var normalized = NormalizedPlaintext(plaintext);
        if (string.IsNullOrEmpty(normalized))
            return new List<string>();
        
        var len = normalized.Length;
        var ncolumn = (int)Math.Ceiling(Math.Sqrt(len));
        
        var segment = new List<string>();
        for (int i = 0; i < normalized.Length; i += ncolumn)
        {
            int length = Math.Min(ncolumn, normalized.Length - i);
            segment.Add(normalized.Substring(i,length));
        }

        return segment;
    }

    public static string Encoded(string plaintext)
    {
        var segments = PlaintextSegments(plaintext);
        return string.Join("", segments);
    }

    public static string Ciphertext(string plaintext)
    {
        var segment = PlaintextSegments((plaintext)).ToList();
        if (!segment.Any())
            return "";
        
        var len = segment[0].Length;
        var result = new List<string>();
        for (int i = 0; i < segment.Count; i++)
        {
            if (segment[i].Length < segment[0].Length)
            {
                segment[i] = segment[i].PadRight(len, ' ');
            }
        }

        for (int i = 0; i < len; i++)
        {
            var columnChars = new List<char>();
            for (int j = 0; j < segment.Count; j++)
            {
                columnChars.Add(segment[j][i]);
            }
            result.Add(new string(columnChars.ToArray()));
        }
        return string.Join(" ", result);
    }
}