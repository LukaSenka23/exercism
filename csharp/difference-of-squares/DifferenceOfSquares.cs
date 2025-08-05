public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        int sum = 0;
        for (int n = 1; n <= max; n++)
        {
            sum += n;
        }

        return sum * sum;
    }

    public static int CalculateSumOfSquares(int max)
    {
        int sum = 0;
        for (int n = 1; n <= max; n++)
        {
            sum += n * n;
        }
        
        return sum;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}