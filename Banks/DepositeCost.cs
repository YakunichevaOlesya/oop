namespace Lab4
{
    public class DepositeCost : Cost
    {
        public DepositeCost(int id_, float money_, CostSettings settings) // нижний предел-процент
            : base(id_)
        {
            ID = id_;
            Money = money_;
            Term.AddMonths(settings.TermMonth);
            IncreasingPercent = settings.PercentageDiapazon.FindLast(item => item.Key <= money_).Value;
        }
    }
}
