using System;

namespace scg.Utils
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }

    public class DateTimeWrapper : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
