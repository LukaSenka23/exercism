public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0)
            throw new ArgumentException();
        
        var dp = new List<int>[target + 1];
        dp[0] = new List<int>();
        
        for (int amount = 1; amount <= target; amount++)
        {
            foreach (var coin in coins)
            {
                if (coin <= amount && dp[amount - coin] != null)
                {
                    var candidate = new List<int>(dp[amount - coin]) {coin};//Na kraju, dodaj i ovaj coin u novu listu.
                    if (dp[amount] == null || candidate.Count < dp[amount].Count)
                        dp[amount] = candidate;
                }
            }
        }

        if (dp[target] == null)
            throw new ArgumentException();
        
        dp[target].Reverse();//sadrži listu kovanica koje daju sumu target sa najmanjim brojem kovanica.
        return dp[target].ToArray();
    }
}