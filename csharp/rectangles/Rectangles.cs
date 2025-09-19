public static class Rectangles
{
    public static int Count(string[] rows)
    {
        var segments = new List<(int start, int end)>();
        int count = 0;
        for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
        {
            var row = rows[rowIndex];
            for (var corner = 0; corner < row.Length - 1; corner++)
            {
                var cell = row[corner];

                if (cell == '+')
                {
                    for (int side = corner + 1; side < row.Length; side++)
                    {
                        if (row[side] == '+')
                        {
                            // provera da li je izmedju njih sve '-' ili '+'
                            bool horizontal = true;
                            for (int k = corner + 1; k < side; k++)
                            {
                                if (row[k] != '-' && row[k] != '+')
                                {
                                    horizontal = false;
                                    break;
                                }
                            }

                            if (horizontal)
                            {
                                for (int rowBottom = rowIndex + 1; rowBottom < rows.Length; rowBottom++)
                                {
                                    if (rows[rowBottom][corner] == '+' && rows[rowBottom][side] == '+')
                                    {
                                        var vertical = true;
                                        for (int k = rowIndex + 1; k < rowBottom; k++)
                                        {
                                            if (rows[k][corner] != '|' && rows[k][corner] != '+')
                                                vertical = false;
                                            if (rows[k][side] != '|' && rows[k][side] != '+')
                                                vertical = false;

                                        }

                                        for (int i = corner + 1; i < side; i++)
                                        {
                                            if (rows[rowBottom][i] != '-' && rows[rowBottom][i] != '+')
                                            {
                                                vertical = false;
                                                break;
                                            }
                                        }

                                        if (vertical)
                                            count++;
                                    }
                                }
                            }

                        }
                    }
                }

            }
        }

        return count;
    }
}