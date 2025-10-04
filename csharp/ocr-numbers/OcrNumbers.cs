public static class OcrNumbers
{
    public static readonly Dictionary<string, char> DigitPatterns = new()
    {
        { 
            " _ " +
            "| |" +
            "|_|" +
            "   ", '0' 
        },
        { 
            "   " +
            "  |" +
            "  |" +
            "   ", '1' 
        },
        { 
            " _ " +
            " _|" +
            "|_ " +
            "   ", '2' 
        },
        { 
            " _ " +
            " _|" +
            " _|" +
            "   ", '3' 
        },
        { 
            "   " +
            "|_|" +
            "  |" +
            "   ", '4' 
        },
        { 
            " _ " +
            "|_ " +
            " _|" +
            "   ", '5' 
        },
        { 
            " _ " +
            "|_ " +
            "|_|" +
            "   ", '6' 
        },
        { 
            " _ " +
            "  |" +
            "  |" +
            "   ", '7' 
        },
        { 
            " _ " +
            "|_|" +
            "|_|" +
            "   ", '8' 
        },
        { 
            " _ " +
            "|_|" +
            " _|" +
            "   ", '9' 
        }
    };
    public static string Convert(string input)
    {
        var rows = input.Split("\n");
        if (rows.Length % 4 != 0)
            throw new ArgumentException();
        if (rows.Any(r => r.Length % 3 != 0))
            throw new ArgumentException();
        
        var allLines = new List<string>();
        for (int i = 0; i < rows.Length; i+=4)
        {
            var result = new List<string>();
            for (int j = 0; j < rows[i].Length ; j+=3)
            {
                var save = new List<string>();
                foreach (var row in rows.Skip(i).Take(4))
                {
                    var slice = row.Substring(j, 3);
                    save.Add(slice);

                }

                var digitPattern = string.Join("",save);
                if(DigitPatterns.ContainsKey(digitPattern))
                    result.Add(DigitPatterns[digitPattern].ToString());
                else
                    result.Add("?");
                
            }
            allLines.Add(string.Join("",result));
        }

        return string.Join(",",allLines);
    }
}