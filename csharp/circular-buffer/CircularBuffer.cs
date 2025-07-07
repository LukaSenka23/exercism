public class CircularBuffer<T>(int capacity)
{
    private readonly T[] _buffer = new T[capacity];
    private int _readIndex;
    private int _writeIndex;
    private bool _isFull;

    public T Read()
    {
        if (!_isFull && _readIndex == _writeIndex)
        {
            throw new InvalidOperationException();
        }

        var value = _buffer[_readIndex];
        _readIndex = (_readIndex + 1) % _buffer.Length;
        _isFull = false;
        return value;
    }

    public void Write(T value)
    {
        if (_isFull)
        {
            throw new InvalidOperationException();
        }

        _buffer[_writeIndex] = value ;
        _writeIndex = (_writeIndex + 1) % _buffer.Length;
        _isFull = _writeIndex == _readIndex;
    }

    public void Overwrite(T value)
    {
        if (_isFull)
        {
            _buffer[_writeIndex] = value;
            _writeIndex = (_writeIndex + 1) % _buffer.Length;
            _readIndex = (_readIndex + 1) % _buffer.Length;
        }
        else
        {
            Write(value);
        }
    }

    public void Clear()
    {
        _readIndex = 0;
        _writeIndex = 0;
        _isFull = false;
    }
}