public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (digits == " ")
            throw new ArgumentException();
        if (span < 0)
            throw new ArgumentException();
        if (digits.Length < span)
            throw new ArgumentException();
        
        var result = new List<int>();
        
        foreach (var digit in digits)
        {
            var letter = char.IsLetter(digit);
            if (letter == true)
                throw new ArgumentException();
        }

        for (int i = 0; i <= digits.Length - span; i++)
        {
                var num = 1;
                for (int j = 0; j < span; j++)
                {
                    int operation =  digits[i + j] - '0';
                    num *= operation;
                }
                result.Add(num);
        }

        return result.Max();
    }
} 