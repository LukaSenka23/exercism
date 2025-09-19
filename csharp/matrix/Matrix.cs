public class Matrix
{
    private string input;
    public Matrix(string input)
    {
        this.input = input;
    }
    
    public int[] Row(int row)
    {
        var result = new List<int>();
        var split =  input.Split('\n');
        var one = split[row - 1];
        var numbers = one.Split(" ");
        foreach (var num in numbers)
        {
           result.Add(int.Parse(num));
        }

        return result.ToArray();
    }

    public int[] Column(int col)
    {
        var result = new List<int>();
        var split =  input.Split('\n');
        foreach (var row in split)
        {
           var numbers = row.Split(" ");
            var column =  numbers[col - 1];
            result.Add(int.Parse(column));
        }

        return result.ToArray();
    }
}