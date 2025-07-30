public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var splits = phrase.Split(new[] { ' ', '-' ,'_'}, StringSplitOptions.RemoveEmptyEntries);
        var letter = new List<char>();
        
        foreach (string word in splits)
        {
            if (word.Length == 0)
            {
                continue;
            }
            
            var bigLetters =  char.ToUpper(word[0]);
            letter.Add(bigLetters);
        }
        return new string(letter.ToArray());
    }
}