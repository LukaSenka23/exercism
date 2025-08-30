public static class RomanNumeralExtension
{
    private static Dictionary<string, int> romanCombo = new()
    {
        {"M", 1000},
        {"CM", 900},
        {"D", 500},
        {"CD", 400},
        {"C", 100},
        {"XC", 90},
        {"L", 50},
        {"XL", 40},
        {"X", 10},
        {"IX", 9},
        {"V", 5},
        {"IV", 4},
        {"I", 1}
    };
    public static string ToRoman(this int value)
    {
        var result = "";
        foreach (var numbers in romanCombo)
        {
            var romanKey = numbers.Key;
            int romanValue = numbers.Value;
         
                while (value >= romanValue)
                {
                    result += romanKey;
                    value -= romanValue;
                }
        }

        return result;
    }
}