namespace banking.Events
{
    public class MoneyWithdrawnEventArgs : EventArgs
    {
        public double Amount { get; }

        public MoneyWithdrawnEventArgs(double amount)
        {
            Amount = amount;
        }
    }
}
