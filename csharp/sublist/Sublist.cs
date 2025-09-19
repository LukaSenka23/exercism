public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1.SequenceEqual(list2))
            return SublistType.Equal;

        if (list1.Count <= list2.Count)
        {
            for (int i = 0; i <= list2.Count - list1.Count; i++)
            {
                if (list2.Skip(i).Take(list1.Count).SequenceEqual(list1))
                    return SublistType.Sublist;
            }
        }

        if (list1.Count >= list2.Count)
        {
            for (int i = 0; i <= list1.Count - list2.Count; i++)
            {
                if (list1.Skip(i).Take(list2.Count).SequenceEqual(list2))
                    return SublistType.Superlist;
            }
        }

        return SublistType.Unequal;
    }
}