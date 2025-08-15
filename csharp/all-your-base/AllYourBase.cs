public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2)
            throw new ArgumentException();
        if (outputBase < 2)
            throw new ArgumentException();
        if (inputDigits.Length == 0)
            return new int[] { 0 };

        var saver = new List<int>();

        foreach (var digit in inputDigits)
        {
            if (digit < 0 || digit >= inputBase)
                throw new ArgumentException();
        }

        var digits = inputDigits.SkipWhile(d => d == 0).ToArray();
        if (digits.Length == 0)
            return new int[] { 0 };
        
        var decimalValue = 0;
        foreach (var digit in digits)
        {
            decimalValue = decimalValue * inputBase + digit;
        }

        while (decimalValue > 0)
        {
            saver.Insert(0,decimalValue % outputBase);
            decimalValue /= outputBase;
        }
        return saver.ToArray();
    }
}