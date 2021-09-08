namespace Lab0.Models
{
    public class GroupName
    {
        public int X { get; set; } // Course Number
        public int YY { get; set; } // Group Number
        public override string ToString()
        {
            return "M3" + X.ToString() + YY.ToString();
        }
    }
}
