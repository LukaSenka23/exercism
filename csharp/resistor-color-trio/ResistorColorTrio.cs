public static class ResistorColorTrio
{
    enum Colors
    {
        black = 0,
        brown= 1,
        red = 2,
        orange = 3,
        yellow = 4,
        green = 5,
        blue = 6,
        violet = 7,
        grey = 8,
        white = 9
    }
    public static string Label(string[] colors)
    {
        var (first,second,third) = (colors[0],colors[1],colors[2]);
        var firstValue = (int)Enum.Parse(typeof(Colors), first,true);
        var secondValue = (int)Enum.Parse(typeof(Colors), second,true);
        var thirdValue = (int)Enum.Parse(typeof(Colors), third,true);
        var multiplier = (long)Math.Pow(10, thirdValue);
        
        var ohmsValue = (firstValue * 10 + secondValue) * multiplier;
        return ohmsValue switch
        {
            >= 1_000_000_000 => $"{(ohmsValue / 1_000_000_000).ToString()} gigaohms",
            >= 1_000_000 => $"{(ohmsValue / 1_000_000).ToString()} megaohms",
            >= 1_000 => $"{(ohmsValue / 1_000).ToString()} kiloohms",
            _ => $"{ohmsValue} ohms"
        };

    }
}
