public static class TwoFer
{
    // In order to get the tests running, first you need to make sure the Speak method 
    // can be called both without any arguments and also by passing one string argument.
    public static string Speak()
    {
        return Speak(null);
    }

    public static string Speak(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return $"One for you, one for me.";
        }
        else
        {
            return $"One for {name}, one for me.";
        }
    }
}