using System.Diagnostics;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var numbers = new List<T>();
        foreach (var number in collection)
        {
            if (predicate(number))
            {
                numbers.Add(number);
            }
        }

        return numbers.ToArray();
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var numbers = new List<T>();
        foreach (var number in collection)
        {
            if (predicate(number) == false )
            {
                numbers.Add(number);
            }
        }

        return numbers.ToArray();
    }
}