using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Bank
{
    class Bank
    {
        public string Name;
        public List<Client> Clients= new List<Client>();

        public CostSettings CreditSettings = new CostSettings();
        public CostSettings DepositeSettings = new CostSettings();
        public CostSettings DebitSettings = new CostSettings();

        private int LastID = 0;

        public float MaxForAnonimus = 15000;

        public List<Log> Logs = new List<Log>();
        int LastTransactionID = 0;


        public Bank(string name_, CostSettings CreditSettings_, CostSettings DepositeSettings_, CostSettings DebitSettings_)
        {
            CreditSettings = CreditSettings_;
            DepositeSettings = DepositeSettings_;
            DebitSettings = DebitSettings_;
            Name = name_;
        }


        public Client NewClient(string Name, string address, int passport)
        {
            Client client = new Client(Name, address, passport);
            Clients.Add(client);
            return client;
        }
        public Client NewClient(string Name)
        {
            return NewClient(Name, "", -1);
        }


        public DebitCost NewDebitCost(Client client)
        {
            DebitCost debit = new DebitCost(LastID++, DebitSettings);
            Clients.Find(item => item.Name == client.Name).Costs.Add(debit);
            return debit;
        }

        public CreditCost NewCreditCost(Client client)
        {
            CreditCost credit= new CreditCost(LastID++, CreditSettings);
            Clients.Find(item => item.Name == client.Name).Costs.Add(credit);
            return credit;
        }

        public DepositeCost NewDepositeCost(Client client, float money_)
        {
            DepositeCost deposite = new DepositeCost(LastID++, money_, CreditSettings);
            Clients.Find(item => item.Name == client.Name).Costs.Add(deposite);
            return deposite;
        }

        public int AddMoney(Client client, Cost cost, float money)
        {
            client = Clients.Find(item => item.Name == client.Name);
            if (client != null)
            {
                cost = client.Costs.Find(item => item.ID == cost.ID);
                if (cost != null)
                {
                    cost.AddMoney(money);
                    Logs.Add(new Log(LastTransactionID++, client, cost, money, "give"));
                    return LastTransactionID - 1;
                }
                else throw new Exception($"{client.Name} doesn't have this cost");
            }
            else throw new Exception("There is no such a client");
        }

        public int TakeMoney(Client client, Cost cost, float money)
        {
            client = Clients.Find(item => item.Name == client.Name);
            if (client != null)
            {
                cost = client.Costs.Find(item => item.ID == cost.ID);
                if (cost != null)
                {
                    if (!client.IsVerified() && money > MaxForAnonimus)
                        throw new Exception("Transaction denied");
                    else
                    {
                        cost.TakeMoney(money);
                        Logs.Add(new Log(LastTransactionID++, client, cost, money, "take"));
                        return LastTransactionID - 1;
                    }
                }
                else throw new Exception($"{client.Name} doesn't have this cost");
            }
            else throw new Exception("There is no such a client");
        }

        public int SendMoney(Client client, Cost costfrom, Cost costto, float money)
        {
            int CurTransaction = LastTransactionID;
            try
            {
                TakeMoney(client, costfrom, money);
                LastTransactionID--;
                AddMoney(client, costto, money);
                return LastTransactionID - 1;
            }
            catch
            {
                BackUp(CurTransaction);
                BackUp(CurTransaction);
                throw new Exception("Transaction error occured");
            }
        }

        public void BackUp(int TransactionId)
        {
            Log log = Logs.Find(item => item.TransactionID == TransactionId);
            if (log == null)
                return;
            Logs.Remove(log);
            if (log.OperationType == "give")
                TakeMoney(log.client, log.cost, log.Money);
            else
                AddMoney(log.client, log.cost, log.Money);

        }
        public void DayPassed()
        {
            foreach(Client client in Clients)
            {
                client.DayPassed();
            }
        }
        public void MonthPassed()
        {
            foreach (Client client in Clients)
            {
                client.MonthPassed();
            }
        }
    }
}
