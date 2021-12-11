﻿using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5.Deliters
{
    public class DeliterByDate : IDelitable<DateTime>
    {
        public List<int> DeleteByCriterion(DateTime date, List<RestorePoint> points)
            => points.Where(d => DateTime.Compare(d.CreationTime, date) <= 0).Select(d => d.ID).ToList();
    }
}
