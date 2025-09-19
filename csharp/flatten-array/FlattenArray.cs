using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        var result = new List<object?>();
        foreach (var obj in input)
        {
            if (obj is null )
                continue;
            else if(obj is int number)
                result.Add(number);
            else if (obj is IEnumerable nested)
            {
                foreach (var i in Flatten(nested))
                    result.Add(i);
            }
        }

        return result;
    }
}