public static class FlowerField
{
    public static string[] Annotate(string[] input)
    {
        var rowCount = input.Length;
        if (rowCount == 0) return Array.Empty<string>();
        
        var columnCount = input[0].Length;
        var result = new List<string>();
        
        for (int i = 0; i < rowCount; i++)
        {
            var row = new List<char>();
            for (int j = 0; j < columnCount; j++)
            {
                char ch = input[i][j];
                if (ch == '*')
                {
                    row.Add('*');
                }
                else
                {
                    int count = FlowersCount(i, j,input);
                    row.Add(count == 0 ? ' ':count.ToString()[0]);
                }
            }
            
            result.Add(new string(row.ToArray()));
        }

        return result.ToArray();
    }

    private static int FlowersCount(int row, int column,string[] input)
    {
        var count = 0;
        var rowCount = input.Length;
        var columnCount = input[0].Length;
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = column - 1; j <= column + 1; j++)
            {
                if (i >= 0 && i < rowCount && j >= 0 && j < columnCount)
                {
                    if(i == row && j == column)
                        continue;
                    if (input[i][j] == '*')
                        count++;
                }
            }
        }
        return count;
    }
    
}
