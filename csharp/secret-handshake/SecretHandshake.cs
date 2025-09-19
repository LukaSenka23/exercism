public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        string[] words = { "wink", "double blink", "close your eyes", "jump" };
        var result = new List<string>();
        var index = 0;
        foreach (var word in words)
        {
            if ((commandValue & (1 << index)) != 0)
            {
                result.Add(word);
            }
            index++;
        }

        if ((commandValue & 16) != 0)
        {
            result.Reverse();
        }

        return result.ToArray();

    }
}
