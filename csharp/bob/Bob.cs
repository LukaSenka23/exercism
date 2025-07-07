public static class Bob
{
    public static string Response(string statement)
    {
        bool hasLetters = statement.Any(c => char.IsLetter(c));
        bool allLettersUpper = statement.Where(char.IsLetter).All(c => char.IsUpper(c));
        bool isShouting = hasLetters && allLettersUpper;
        bool isQuestion = statement.Trim().EndsWith("?");
        bool isSilence = string.IsNullOrWhiteSpace(statement);
        
        if (isQuestion && isShouting)
        {
            return "Calm down, I know what I'm doing!";
        }
        else if (isSilence)
        {
            return "Fine. Be that way!";
        }
        else if (isShouting)
        {
            return "Whoa, chill out!";
        }
        else if (isQuestion)
        {
            return "Sure.";
        }
        else
        {
            return "Whatever.";
        }
        
    }
}   