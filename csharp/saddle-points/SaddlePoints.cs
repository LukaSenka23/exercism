public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var row = matrix.GetLength(0);
        var column = matrix.GetLength(1);
            for (int r = 0; r < row; r++)
            {
                int maxRow =  Int32.MinValue;
                for (int c = 0; c < column; c++)
                {
                    if (matrix[r, c] > maxRow)
                        maxRow = matrix[r, c];
                }
                for (int c = 0; c < column; c++)
                {
                    int minColumn = Int32.MaxValue;
                    for (int i = 0; i < row; i++)
                    {
                        if (matrix[i, c] < minColumn)
                            minColumn = matrix[i, c];
                    }
                    int candidate = matrix[r, c];
                    bool isSaddle = (candidate == maxRow && candidate == minColumn) ;
                    if (isSaddle)
                        yield return (r + 1, c + 1);
                }
            }
    }
}
