using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public interface IDelitable<T>
    {
        List<int> DeleteByCriterion(T criterion, List<RestorePoint> points);
    }
}
