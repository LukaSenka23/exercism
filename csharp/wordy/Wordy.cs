public static class Wordy
{
    public static int Answer(string question)
    {
        question = question.Replace("multiplied by", "multiplied_by").Replace("divided by", "divided_by");
        
        var token = question
            .Replace("What is ", "")
            .Replace("?", "").Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var operators = new List<string> { "plus", "minus", "multiplied_by" , "divided_by" };
        
        string lastOp = null;
        int result = 0;
        bool expectNumber = true;//prvo ocekujemo broj
        foreach (var s in token)
        {
            if (operators.Contains(s))
            {
                if (expectNumber)
                    throw new ArgumentException();
                lastOp = s;
                expectNumber = true;// posle operatora ocekujemo broj 
            }
            else
            {
                if (!int.TryParse(s, out int number))
                    throw new ArgumentException();
                if (!expectNumber)
                    throw new ArgumentException();
                
                if (lastOp == null)
                {
                    result = number;
                }
                else
                {
                    switch (lastOp)
                    {
                        case "plus":
                            result += number;
                            break;
                        case "minus":
                            result -= number;
                            break;
                        case "multiplied_by":
                            result *= number;
                            break;
                        case "divided_by":
                            result /= number;
                            break;
                            
                    }
                    lastOp = null;
                }

                expectNumber = false;
            }
        }

        if (expectNumber)
            throw new ArgumentException();

        return result;
    }
}