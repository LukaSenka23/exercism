public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        var left = 0;
        var right = input.Length - 1;
        
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (input[mid] > value)
                right = mid - 1;
            else if (input[mid] < value)
                left = mid + 1;
            else
                return mid;
        }

        return -1;  
    }
    
}