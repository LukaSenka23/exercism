public static class BottleSong
{
    private static string[] Numbers =
    {
        "no", "one", "two", "three", "four", "five",
        "six", "seven", "eight", "nine", "ten"
    };
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        List<string> lines = new List<string>();

        for (int i = startBottles; i > startBottles - takeDown ; i--)
        {
            string current = Numbers[i];
            string result = Numbers[i - 1];
            current = char.ToUpper(current[0]) + current.Substring(1);
            
            lines.Add($"{current} green bottle{(i > 1 ? "s" : "")} hanging on the wall,");
            lines.Add($"{current} green bottle{(i > 1 ? "s" : "")} hanging on the wall,");
            lines.Add("And if one green bottle should accidentally fall,");

            lines.Add($"There'll be {result} green bottle{(i - 1 == 1 ? "" : "s")} hanging on the wall.");
            
            if (i > startBottles - takeDown + 1)
                lines.Add("");
        }

        return lines;
    }
}
