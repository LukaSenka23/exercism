public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] result = new byte[9];
        

        if (reading >= 0 && reading <= ushort.MaxValue)
        {
            result[0] = 0x02;
            var bytes = BitConverter.GetBytes((ushort)reading);
            Array.Copy(bytes, 0, result, 1, bytes.Length);
        }
        else if (reading >= short.MinValue && reading <= short.MaxValue)
        {
            result[0] = 0xFE;
            var bytes = BitConverter.GetBytes((short)reading);
            Array.Copy(bytes, 0, result, 1, bytes.Length);
        }
        else if (reading >= int.MinValue && reading <= int.MaxValue)
        {
            result[0] = 0xFC;
            var bytes = BitConverter.GetBytes((int)reading);
            Array.Copy(bytes, 0, result, 1, bytes.Length);
        }
        else if (reading >= 0 && reading <= uint.MaxValue)
        {
            result[0] = 0x04;
            var bytes = BitConverter.GetBytes((uint)reading);
            Array.Copy(bytes, 0, result, 1, bytes.Length);
        }
        else
        {
            result[0] = 0xF8;
            var bytes = BitConverter.GetBytes(reading);
            Array.Copy(bytes, 0, result, 1, bytes.Length);
        }

        return result;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];

        switch (prefix)
        {
            case 0x02:
                return BitConverter.ToUInt16(buffer, 1);

            case 0xFE:
                return BitConverter.ToInt16(buffer, 1);

            case 0xFC:
                return BitConverter.ToInt32(buffer, 1);

            case 0x04:
                return BitConverter.ToUInt32(buffer, 1);

            case 0xF8:
                return BitConverter.ToInt64(buffer, 1);

            default:
                return 0;
        }
    }
}