using System.Collections.Generic;

namespace Lab5.Models
{
    public interface IDelitable<T>
    {
        List<int> DeleteByCriterion(T criterion, List<RestorePoint> points);
    }
}
