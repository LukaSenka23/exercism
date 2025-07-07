public class Clock : IEquatable<Clock>
{
    
    private int _hours;
    private readonly int _minutes;

    public Clock(int hours, int minutes)
    {
       SetHours(hours);
        _minutes = minutes % 60;
        if (_minutes < 0)
        {
            _minutes += 60;
            _hours -= 1;
        }
        SetHours(_hours + minutes / 60);
    }

    private void SetHours(int hours)
    {
        _hours = hours % 24;
        if (_hours < 0) _hours += 24;
    }
    
    public Clock Add(int minutesToAdd)
    {
        var result = (_hours * 60 + _minutes + minutesToAdd);
        return new Clock(0,result);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        var result = (_hours * 60 + _minutes - minutesToSubtract);
        return new Clock(0, result);
    }
    
    public override string ToString()
    {
        return $"{_hours:D2}:{_minutes:D2}";
    }
    
    public bool Equals(Clock other)
    {
        return _hours == other._hours && _minutes == other._minutes;
    }
    
    public override bool Equals(object obj)
    {
        return obj is Clock other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_hours, _minutes);
    }
}