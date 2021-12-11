namespace Lab4.Tests
{
    public class BankTest
    {
        private readonly Bank _bank;
        private readonly DebitCost _debit;
        private readonly CreditCost _credit;
        public BankTest(Bank bank)
        {
            _bank = bank;

            Client Ivan = _bank.Clients[0];
            _debit = _bank.NewDebitCost(Ivan);

            _bank.AddMoney(Ivan, _debit, 50000);

            Ivan.AddAddress("Lenina street");
            Ivan.AddPassport(123456);

            _bank.TakeMoney(Ivan, _debit, 10000);

            _credit = _bank.NewCreditCost(Ivan);
            _bank.TakeMoney(Ivan, _credit, 100000);
        }

        public bool CheckIsClientVerified(Client client)
        {
            if (client.IsVerified())
            {
                return true;
            }

            throw new BankException("Error check is client verified");
        }

        public bool CheckDebitCostBeforeMonth()
        {
            if (_debit.Money == 40000)
            {
                return true;
            }

            throw new BankException("Error check debit cost before month");
        }

        public bool CheckCreditCostBeforeMonth()
        {
            if (_credit.Money == -100000)
            {
                return true;
            }

            throw new BankException("Error check credit cost before month");
        }

        public bool CheckDebitCostAfterMonth()
        {
            _bank.DayPassed();
            _bank.MonthPassed();
            if (_debit.Money == 41200)
            {
                return true;
            }

            throw new BankException("Error check debit cost after month");
        }

        public bool CheckCreditCostAfterMonth()
        {
            if (_credit.Money == -105000)
            {
                return true;
            }

            throw new BankException("Error check credit cost after month");
        }


    }
}
