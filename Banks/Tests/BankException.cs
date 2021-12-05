using System;

namespace Lab4.Tests
{
    public class BankException : Exception
    {
        public BankException(string message) : base(message) { }
    }
}
