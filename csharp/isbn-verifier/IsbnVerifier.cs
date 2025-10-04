public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var sum = 0;
        var digits = new List<int>();
       number = number.Replace("-", "");
        
        if (number.Length != 10)
            return false;
        
        for (var i = 0;i< number.Length;i++)
        {
            char ch = number[i];
            
            if (char.IsDigit(ch))
                digits.Add(ch -'0');
            else if (ch == 'X')
            {
                if (i == 9)
                    digits.Add(10);
                else
                    return false;
            }
            else
                return false;
        }
        for (int d = 0; d < 10; d++)
        {
            sum += digits[d] * (10 - d);
        }

        return sum % 11 == 0;
    }
}