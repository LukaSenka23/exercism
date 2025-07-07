using System.Reflection.Metadata.Ecma335;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var dominoesList = dominoes.ToList();
        var rotation = new List<(int, int)>();
        
        foreach (var(left,right) in dominoesList)
        {
            
        }
        
    }
}