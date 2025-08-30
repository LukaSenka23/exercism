public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
       
        var result = new List<string>();
        
        for (int i = 0; i < subjects.Length - 1; i++)
        {
            var subject = subjects[i];
            result.Add($"For want of a {subject} the {subjects[i + 1]} was lost.");
        }

        if (subjects.Length > 0)
        {
            result.Add($"And all for the want of a {subjects[0]}.");
        }

        return result.ToArray();
    }
}