using System.Runtime.InteropServices.JavaScript;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        if (string.IsNullOrEmpty(input))
            return true;
        
        var stack = new Stack<char>();
        List<char> opening = ['(', '[', '{'];
        List<char> closing = [')', ']', '}'];
        
        foreach (char bracket in input)
        {
            var ixc = closing.IndexOf(bracket);
            if (-1 != opening.IndexOf(bracket))
                stack.Push(bracket);
            else if (ixc != -1)
            {
                if (stack.Count == 0 || opening.IndexOf(stack.Pop()) != ixc)
                    return false;
            }
        }
        return stack.Count == 0;
    }
}
