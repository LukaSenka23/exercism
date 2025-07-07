public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
            List<uint> result = new List<uint>();
        foreach (var n in numbers)
        {
            List<uint> parts = new List<uint>();
            var number = n;
            if (number == 0)
            {
                result.Add(0);
                continue;
            }
            while (number > 0)
            {
                byte part = (byte)(number & 0x07F);
                number >>= 7;
                parts.Add(part);
            }
            parts.Reverse();
            
            for (int i = 0; i < parts.Count - 1; i++)
            {
                parts[i] |= 0x80;
            }
            result.AddRange(parts);
        }
        return result.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
            List<uint> result = new List<uint>();
            uint value = 0;
            bool inSequence = false;
        foreach (var b in bytes)
        {
               value = (value <<= 7) | (b & 0x7F);
               inSequence = true;
               
            if ((b & 0x80) == 0)
            {
                result.Add(value);
                value = 0;
                inSequence = false;
            }

        }
            if (inSequence)
            {
                throw new InvalidOperationException("Incomplete sequence");
            }
            return result.ToArray();
    }
}