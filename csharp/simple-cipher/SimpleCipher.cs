public class SimpleCipher
{
    private string key;
    public SimpleCipher()
    {
        var random = new Random();
        var chars = new char[100];
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)('a' + random.Next(0, 26));
        }

        key = new string(chars);
    }

    public SimpleCipher(string key)
    {
        this.key = key;
    }
    
    public string Key 
    {
        get {return key;}
    }

    public string Encode(string plaintext)
    {
        char[] result = new char[plaintext.Length];
        for (int i = 0; i < plaintext.Length; i++)
        {
            int shift = Key[i % Key.Length]- 'a';
            var value = (plaintext[i] - 'a' + shift) % 26;
            result[i] = (char)('a' + value);
        }

        return new string(result);
    }

    public string Decode(string ciphertext)
    {
        char[] result = new char[ciphertext.Length];
        for (int i = 0; i < ciphertext.Length; i++)
        {
            int shift = Key[i % Key.Length] - 'a';
            int value = (ciphertext[i] - 'a' - shift + 26) % 26;
            result[i] = (char)('a' + value);
        }
        return new string(result);
    }
}