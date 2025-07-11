public static class Forth
{
    private static string EvaluateInternal(string instructions)
    {
        Stack<int> stack = new Stack<int>();

        var tokens = instructions.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (var token in tokens)
        {
            var lowerToken = token.ToLower();

            if (int.TryParse(token, out int value))
            {
                stack.Push(value);
                continue;
            }

            switch (lowerToken)
            {
                case "+":
                    if (stack.Count < 2)
                        throw new InvalidOperationException();
                    var a = stack.Pop();
                    var b = stack.Pop();
                    stack.Push(b + a);
                    break;
                case "-":
                    if (stack.Count < 2)
                        throw new InvalidOperationException();
                    a = stack.Pop();
                    b = stack.Pop();
                    stack.Push(b - a);
                    break;
                case "*":
                    if (stack.Count < 2)
                        throw new InvalidOperationException();
                    a = stack.Pop();
                    b = stack.Pop();
                    stack.Push(b * a);
                    break;
                case "/":
                    if (stack.Count < 2)
                        throw new InvalidOperationException();
                    a = stack.Pop();
                    b = stack.Pop();
                    if (a == 0)
                        throw new DivideByZeroException();
                    stack.Push(b / a);
                    break;
                case "dup":
                    if (stack.Count < 1)
                        throw new InvalidOperationException();
                    stack.Push(stack.Peek());
                    break;
                case "swap":
                    if (stack.Count < 2)
                        throw new InvalidOperationException();
                    a = stack.Pop();
                    b = stack.Pop();

                    stack.Push(a);
                    stack.Push(b);
                    break;
                case "drop":
                    if (stack.Count < 1)
                        throw new InvalidOperationException();
                    stack.Pop();
                    break;
                case "over":
                    if (stack.Count < 2)
                        throw new InvalidOperationException();
                    int[] temp = stack.ToArray();
                    stack.Push(temp[1]);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        return string.Join(" ", stack.Reverse());
    }

    public static string Evaluate(string[] instructions)
    {
        var words = new Dictionary<string, string[]>();

        var definitions = instructions[..^1];
        var toEvaluate = instructions[^1].ToLower();

        foreach (var definition in definitions)
        {
            var def = definition.ToLower()[1..^1].Trim().Split(" ");
            var key = def[0];
            if (int.TryParse(key, out _)) throw new InvalidOperationException();
            var replacements = Replace(def[1..], words);
                
            words[key] = replacements;
        }

        var replaced = string.Join(' ', Replace(toEvaluate.Split(" "), words));
            
        return EvaluateInternal(replaced);
    }

    private static string[] Replace(string[] strings, Dictionary<string, string[]> words) =>
        strings.Select(d => words.TryGetValue(d, out var word) ? string.Join(' ', word) : d)
            .ToArray();
}