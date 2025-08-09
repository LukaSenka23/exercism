public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        
        var saver = new List<int>();
        foreach (var factor in multiples)     
        {
            if (factor == 0) continue;
            for (int number = factor; number < max ; number += factor)
            {
                if (factor != 0 && number % factor == 0)
                {
                    saver.Add(number);
                }
            }
        }

        return saver.Distinct().Sum();
    }
}   