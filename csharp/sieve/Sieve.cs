public static class Sieve
{
    public static int[] Primes(int limit)
    {
        var result = new List<int>();
        for (int i = 2; i <= limit; i++)
        {
            bool Isprime = true;
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    Isprime = false;
                    break;
                }
            }
            if (Isprime)
                result.Add(i);
        }

        return result.ToArray();
    }
}