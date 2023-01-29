using System;

namespace scg.Utils;

public static class DateTimeExtensions
{
    public static int MonthsSinceY2K(this DateTime end)
    {
        var start = new DateTime(2000, 1, 1);
        return (end.Month + end.Year * 12) - (start.Month + start.Year * 12);
    }
}