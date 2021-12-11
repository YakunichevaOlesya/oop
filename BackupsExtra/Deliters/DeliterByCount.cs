using Lab5.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lab5.Deliters
{
    public class DeliterByCount : IDelitable<int>
    {
        public List<int> DeleteByCriterion(int n, List<RestorePoint> points)
        {
            List<RestorePoint> pointsToSave = new List<RestorePoint>(points);
            List<int> pointsToDelete = new List<int>();
            while (pointsToSave.Count > n) {
                pointsToDelete.Add(pointsToSave.First().ID);
                pointsToSave.RemoveAt(0);
            }

            return pointsToDelete;
        }
    }
}
