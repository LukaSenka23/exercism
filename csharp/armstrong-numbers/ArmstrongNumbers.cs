public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int tempNum = number;
        var digitCount = 0;
        while (tempNum > 0)
        {
            digitCount++;
            tempNum /= 10;
        }

        long sum = 0;
        for (int temp = number; temp > 0 ; temp /= 10)
        {
            int digit = temp % 10;
            sum += (long)Math.Pow(digit, digitCount);
        }

        return sum == number;
    }
}