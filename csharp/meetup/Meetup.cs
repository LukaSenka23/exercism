public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;
    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        if (schedule == Schedule.Teenth )
        {
            for (int i = 13; i <= 19; i++)
            {
                var date = new DateTime(_year, _month, i);
                if (date.DayOfWeek == dayOfWeek)
                {
                    return date;
                }
            }
        }

        else if (schedule == Schedule.First )
        {
            var date = new DateTime(_year, _month, 1);
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(1);
            }

            return date;
        }
        else if (schedule == Schedule.Second)
        {
            var date = new DateTime(_year, _month, 1);
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(1);
            }

            date = date.AddDays(7);
            return date;
        }
        
        else if(schedule == Schedule.Third)
        {
            var date = new DateTime(_year, _month, 1);
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(1);
            }

            date = date.AddDays(14);
            return date;
        }
        
        else if(schedule == Schedule.Fourth)
        {
            var date = new DateTime(_year, _month, 1);
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(1);
            }

            date = date.AddDays(21);
            return date;
        }

        else if (schedule == Schedule.Last)
        {
            var lastDay = new DateTime(_year, _month, DateTime.DaysInMonth(_year,_month));
            while (lastDay.DayOfWeek != dayOfWeek)
            {
                lastDay = lastDay.AddDays(-1);
            }

            return lastDay;
        }

        else
        {
            throw new ArgumentException("Invalid schedule value");
        }

        return default;
    }
}