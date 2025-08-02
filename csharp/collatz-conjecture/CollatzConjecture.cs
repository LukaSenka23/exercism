public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        var n = number;
        var steps = 0;
        
        if (number <= 0)
            throw new ArgumentOutOfRangeException();
        
        while (n != 1)
        {
            if (n % 2 == 0)
            {
                n = n / 2;
            }

            else
            {
                n = 3 * n + 1;
            }

            steps++;
        }

        return steps;
    }
}