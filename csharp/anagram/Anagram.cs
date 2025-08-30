public class Anagram
{
    private string baseWord;
    
    public Anagram(string baseWord)
    {
        var chars = new List<char>();
        this.baseWord = baseWord;
        
        foreach (var ch in baseWord)
        {
            if (char.IsLetter(ch))//uzima sva slova.       
                chars.Add(char.ToLower(ch));
        }
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var result = new List<string>();
        foreach (var match in potentialMatches)
        {
            if (match.Length != baseWord.Length)
                continue;
            var sortMatch = match.ToLower().ToCharArray();//Napraviti listu svih karaktera iz match ili niz.
            Array.Sort(sortMatch);
            var sortBase = baseWord.ToLower().ToCharArray();
            Array.Sort(sortBase);
            
            if (match.ToLower() != baseWord.ToLower() && new string(sortMatch) == new string(sortBase))
                result.Add(match);
        }

        return result.ToArray();
    }
}