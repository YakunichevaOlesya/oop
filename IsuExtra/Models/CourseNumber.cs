namespace Lab0.Models
{
    public class CourseNumber
    {
        private int _number;
        public int Number {
            get => _number;
            set {
                if (value >= 1 && value <= 4) {
                    _number = value;
                }
            }
        }
    }
}
