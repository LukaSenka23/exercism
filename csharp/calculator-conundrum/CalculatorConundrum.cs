public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (operation == null)
        {
            throw new ArgumentNullException();
        }

        if (operation == "")
        {
            throw new ArgumentException();
        }

        int result;
        
        if (operation =="+")
        {
            result = operand1 + operand2;
        }
        else if (operation == "-")
        {
            result = operand1 - operand2;
        }
        else if(operation == "*")
        {
            result = operand1 * operand2;
        }
        else if (operation == "/")
        {
            if (operand2 == 0)
            {
                return "Division by zero is not allowed.";
            }
            result = operand1 / operand2;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }

        return $"{operand1} {operation} {operand2} = {result}";
    }
    
}
