public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        DateTime newDate = moment.AddSeconds(1000000000);
        return newDate;
    }
}