public static class FoodChain
{
    private static readonly Dictionary<string, string> Reactions = new()
    {
        { "fly", "" },
        { "spider", "It wriggled and jiggled and tickled inside her." },
        { "bird", "How absurd to swallow a bird!" },
        { "cat", "Imagine that, to swallow a cat!" },
        { "dog", "What a hog, to swallow a dog!" },
        { "goat", "Just opened her throat and swallowed a goat!" },
        { "cow", "I don't know how she swallowed a cow!" },
        { "horse", "She's dead, of course!" }
    };
    public static string Recite(int verseNumber)
    {
        var animals = new List<string> { 
            "fly", 
            "spider", 
            "bird", 
            "cat", 
            "dog", 
            "goat", 
            "cow", 
            "horse"
        };
        var verseLines = new List<string>();
        var animal = animals[verseNumber - 1];
        
        verseLines.Add($"I know an old lady who swallowed a {animal}.");
        
        if (!string.IsNullOrEmpty(Reactions[animal]))
            verseLines.Add(Reactions[animal]);
        
        if (animal == "horse")
            return string.Join("\n", verseLines);
        
        for (int i = verseNumber - 1; i > 0; i--)
        {
           var line = $"She swallowed the {animals[i]} to catch the {animals[i - 1]}";
           if (animals[i -1] == "spider")
              line += " that wriggled and jiggled and tickled inside her";
           
           verseLines.Add(line + ".");
        }
        verseLines.Add("I don't know why she swallowed the fly. Perhaps she'll die.");
        
        return string.Join("\n", verseLines);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var verse = new List<string>();
        for (int i = startVerse; i <= endVerse; i++)
        {
            verse.Add(Recite(i));
        }

        return string.Join("\n\n", verse);
    }
}