namespace Lab4
{
    public class CreditCost : Cost
    {
        public CreditCost(int id_, CostSettings settings):
            base(id_)
        {
            ID = id_;
            ComissionPercent = settings.Comission;
            BottomLimit = settings.BottomLimit;
        }
    }
}
