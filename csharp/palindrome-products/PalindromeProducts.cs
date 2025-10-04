public static class PalindromeProducts
{   
    public static (int, IEnumerable<(int,int)>) Largest(int minFactor, int maxFactor)
    {
        var largestPalindrome = Int32.MinValue;
        List<(int, int)> pairs = new List<(int, int)>();
        for (int i = minFactor; i <= maxFactor ; i++)
        {
            for (int j = minFactor; j <= maxFactor; j++)
            {
                int product = i * j;
                string s = product.ToString();
                string reversed = new string(s.Reverse().ToArray());
                if (s == reversed)
                {
                    if (product > largestPalindrome)
                    {
                        largestPalindrome = product;
                        pairs.Clear();
                         if (i<= j )
                            pairs.Add((i,j));
                    }
                    else if (product == largestPalindrome)
                    {
                        if (i <= j )
                            pairs.Add((i,j));   
                    }
                    
                }
            }
        }
        if (pairs.Count == 0)
            throw new ArgumentException();

        return (largestPalindrome, pairs);
    }

    public static (int, IEnumerable<(int,int)>) Smallest(int minFactor, int maxFactor)
    {
        var smallestPalindrome = Int32.MaxValue;
        List<(int, int)> pairs = new List<(int, int)>();
        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = minFactor; j <= maxFactor; j++)
            {
                var product = i * j;
                string s = product.ToString();
                string reversed = new string(s.Reverse().ToArray());
                if (s == reversed)
                {
                    if (product < smallestPalindrome)
                    {
                        smallestPalindrome = product;
                        pairs.Clear();
                        if (i <= j )
                            pairs.Add((i,j));
                    }
                    else if (product == smallestPalindrome)
                    {
                        if (i<= j )
                            pairs.Add((i,j));
                    }
                }
            }
        }
        if (pairs.Count == 0)
            throw new ArgumentException();

        return (smallestPalindrome, pairs);
    }
}
