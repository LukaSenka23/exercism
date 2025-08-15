public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        var result = new List<(int ,int ,int)>();
        var numbers = Enumerable.Range(1, sum).ToList();
        
        foreach (var a in numbers)
        {
            foreach (var b in numbers)
            {
                var c = sum - a - b;
                if (a < b && b < c && a * a + b * b == c * c )
                {
                    result.Add((a,b,c));
                }
            }
        }

        return result;
    }
}