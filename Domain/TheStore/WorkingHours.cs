﻿using Microsoft.EntityFrameworkCore;

namespace Domain.TheStore
{
    [Owned]
    public class WorkingHours
    {
        public DayOfWeek Day { get; set; }
        public DateTimeOffset OpeningTime { get; set; }
        public DateTimeOffset ClosingTime { get; set; }
    }
}
