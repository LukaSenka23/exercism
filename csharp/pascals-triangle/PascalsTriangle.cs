public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        var result = new List<List<int>>();

        for (int i = 0; i < rows; i++)
        {
            var currentRows = new List<int>();
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                    currentRows.Add(1);
                else
                    currentRows.Add(result[i - 1][j - 1] + result[i - 1][j]);
            }
            result.Add(currentRows);
        }

        return result;
    }

}