public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var cleaning = phoneNumber.Trim().Split(new string[] { "-", "(", ")",".","+,"," "}, StringSplitOptions.RemoveEmptyEntries);
        var digits = new List<char>();
            
        foreach (var c in phoneNumber)
        {
         if (char.IsDigit(c))
            digits.Add(c);
        }
        
        if (digits.Count < 10 || digits.Count >11)
        {
            throw new ArgumentException();
        }

        if (digits.Count == 11)
        {
            if (digits[0] != '1')
                throw new ArgumentException();
            digits.Remove(digits[0]);
        }

        if (digits[0] == '1' || digits[0] == '0')
            throw new ArgumentException();
        if (digits[3] == '0' || digits[3] == '1')
            throw new ArgumentException();

        return string.Join("", digits);
    }
}