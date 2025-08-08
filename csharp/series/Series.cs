public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
            if (string.IsNullOrEmpty(numbers) || sliceLength <= 0 || sliceLength > numbers.Length)  
            {
                throw new ArgumentException();
            }
            var result = new List<string>();
            for (int i = 0; i <= numbers.Length - sliceLength; i++)
            {
                var sub = numbers.Substring(i, sliceLength);
                result.Add(sub);
            }

            return result.ToArray();
    }
}