using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Bank
{
    class Log
    {
        public readonly int TransactionID;
        public readonly Client client;
        public readonly Cost cost;
        public readonly float Money;
        public readonly string OperationType;

        public Log(int transactionID_, Client client_, Cost cost_, float money_, string operationType_)
        {
            TransactionID = transactionID_;
            client = client_;
            cost = cost_;
            Money = money_;
            OperationType = operationType_;
        }
    }
}
