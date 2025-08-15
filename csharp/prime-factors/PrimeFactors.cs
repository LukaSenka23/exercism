public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var factors = new List<long>();
        var limit= (long)Math.Floor(Math.Sqrt(number));
        var candidates = new List<long>();
        
        for (int i = 2; i <=  limit; i++)
        {
            candidates.Add(i);
        }

        foreach (var candidate in candidates)
        {
            while (number % candidate == 0)
            {
                factors.Add(candidate);
                number /= candidate;
            }
        }
        if (number > 1)
            factors.Add(number);
        return factors.ToArray();
    }
    
}