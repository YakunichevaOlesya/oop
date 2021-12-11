namespace Lab0.Models
{
    public enum MF
    {
        TINT,
        FTMI,
        KTU,
        FTMF,
        BTINS
    }
    public class GroupName
    {
        private int _x;
        public int X { // Course Number
            get => _x;
            set {
                if (value >= 1 && value <= 4) {
                    _x = value;
                }
            }
        }

        private int _y;
        public int YY { // Group Number
            get => _y;
            set {
                if (value >= 1 && value <= 14) {
                    _y = value;
                }
            }
        }

        public MF MegaFaculty { get; set; }
        public override string ToString()
        {
            return MegaFaculty.ToString() + X.ToString() + YY.ToString();
        }
    }
}
