namespace Lab4
{
    public class DebitCost : Cost
    {
        public DebitCost(int id_, CostSettings settings) : base(id_)
        {
            ID = id_;
            IncreasingPercent = settings.IncreasingPercent;
        }
    }
}
