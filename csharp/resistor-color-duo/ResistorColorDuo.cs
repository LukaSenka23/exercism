using System.Drawing;

public static class ResistorColorDuo
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
    public static int Value(string[] colors)
    {
        var (first,second) = (colors[0],colors[1]);
        var firstValue = (int)Enum.Parse(typeof(Colors), first);
        var secondValue = (int)Enum.Parse(typeof(Colors), second);

        return firstValue * 10 + secondValue;
    }
}
