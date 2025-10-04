public static class AffineCipher
{
    public static string Encode(string plainText, int a, int b)
    {
        int m = 26;
        if (Gcd(a, m) != 1)
            throw new ArgumentException();
        var cleaned = new string(plainText.ToLower().Where(c => char.IsLetterOrDigit(c)).ToArray());
        var result = new List<char>();
        foreach (var ch in cleaned)
        {
            if (char.IsLetter(ch))
            {
                int x = char.ToLower(ch) - 'a';
                int y = (a * x + b) % m;
                result.Add((char)(y + 'a'));
            }
            else
                result.Add(ch);
        }

        var encoded = new string(result.ToArray());
        var parts = new List<string>();
        for (int i = 0; i < encoded.Length; i+=5)
        {
            int len = Math.Min(5, encoded.Length - i);
            parts.Add(encoded.Substring(i,len));
        }

        return string.Join(" ", parts);
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        int m = 26;
        var result = new List<char>();
        int ModInverse(int a, int m = 26)
        {
            a = a % m;
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                    return x;
            }

            throw new ArgumentException();
        }

        var cleaned = new string(cipheredText.ToLower().Where(c => char.IsLetterOrDigit(c)).ToArray());
        int aInverse = ModInverse(a, m);
        b = b % m;
        foreach (var ch in cleaned)
        {
            if (char.IsLetter(ch))
            {
                int x = char.ToLower(ch) - 'a';
                int y = (aInverse * (x - b + m)) % m;
                result.Add((char)(y + 'a'));
            }
            else if(char.IsDigit(ch))
                result.Add(ch);
        }
        
        return string.Join("", result);
    }
}