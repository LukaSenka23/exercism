using System.Reflection.Metadata.Ecma335;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var dominoesList = dominoes.ToList();
        if (dominoesList.Count == 0) return true;
<<<<<<< HEAD
        
=======
>>>>>>> 0ae2a71 (Second backup)
        var start = dominoesList[0];
        var rest = dominoesList.Skip(1).ToList();

        return CanChainRecursive(start.Item2, rest, start.Item1);
    }

    private static bool CanChainRecursive(int current, List<(int,int)>remaining ,int start)
    {
        if (remaining.Count == 0)
            return current == start;
        
<<<<<<< HEAD
        for (int i = 0; i < remaining.Count; i++)
        {
            var domino = remaining[i];
            var rest = new List<(int, int)>(remaining);
            rest.RemoveAt(i);

            if (domino.Item1 == current)
            {
                if (CanChainRecursive(domino.Item2, rest, start))
                    return true;
            }
            else if(domino.Item2 == current)
            {
                if (CanChainRecursive(domino.Item1, rest, start))
                    return true;
            }
        }

        return false;
    }
}
=======
        foreach (var(left,right) in dominoesList)
        {
            
        }
        
    }
}
>>>>>>> 0ae2a71 (Second backup)
