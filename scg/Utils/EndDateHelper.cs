// © Baker Hughes Company. All rights reserved.
// This document contains confidential and proprietary information owned by Baker Hughes Company.
// Do not use, copy or distribute without permission.

using System;

namespace scg.Utils
{
    public class EndDateHelper
    {
        private readonly IDateTime _dateTime;

        public EndDateHelper(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public DateTime GetEndDate(int months)
        {
            var today = _dateTime.Now;
            var endDate = today;
            if (today.Day >= 16) endDate = _dateTime.Now.AddMonths(months);

            while (endDate.AddDays(1).Month == endDate.Month)
            {
                endDate = endDate.AddDays(1);
            }

            return endDate;
        }
    }
}