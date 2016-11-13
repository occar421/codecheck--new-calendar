using System;

public class MainApp
{
    static public void Main(string[] args)
    {
        var daysInYear = int.Parse(args[0]);
        var daysInMonth = int.Parse(args[1]);
        var daysInWeek = int.Parse(args[2]);
        var dayElements = args[3].Split('-');
        var year = int.Parse(dayElements[0]);
        var month = int.Parse(dayElements[1]);
        var day = int.Parse(dayElements[2]);

        var c = new NewCalender(daysInYear, daysInMonth, daysInWeek, year, month, day);
        var result = c.GetDayOfWeek();

        Console.WriteLine(result);
    }
}

public class NewCalender
{
    public int DaysInYear { get; }
    public int DaysInMonth { get; }
    public int DaysInWeek { get; }
    public int Year { get; }
    public int Month { get; }
    public int Day { get; }

    public NewCalender(int daysInYear, int daysInMonth, int daysInWeek,
                        int year, int month, int day)
    {
        DaysInYear = daysInYear;
        DaysInMonth = daysInMonth;
        DaysInWeek = daysInWeek;
        Year = year;
        Month = month;
        Day = day;
    }

    public string GetDayOfWeek()
    {
        // divisible daysInMonth
        var baseDaysInYear = DaysInYear - (DaysInYear % DaysInMonth);

        var leapMonthCount = GetLeapMonthCountBy(Year);

        var totalDays = (Year - 1) * baseDaysInYear + leapMonthCount * DaysInMonth  // year
            + (Month - 1) * DaysInMonth + (Day - 1);                                // month & day

        // validation
        bool isDayValid = DaysInMonth >= Day;
        bool isLeapYear = GetLeapMonthCountBy(Year + 1) - leapMonthCount == 1; // count increased by this year?
        bool isMonthValid = DaysInMonth * Month <= DaysInYear ||
                            (isLeapYear && DaysInMonth * Month <= DaysInYear + DaysInMonth);

        var dayOfWeekChar = (char)((int)'A' + (totalDays % DaysInWeek));

        return (isDayValid && isMonthValid) ? dayOfWeekChar.ToString() : "-1";
    }

    int GetLeapMonthCountBy(int year)
        // floor by casting
        => (int)((year - 1) * (DaysInYear % DaysInMonth) / DaysInMonth);
}