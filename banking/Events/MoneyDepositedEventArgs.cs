namespace banking.Events
{
    public class MoneyDepositedEventArgs : EventArgs
    {
        public double Amount { get; }

        public MoneyDepositedEventArgs(double amount)
        {
            Amount = amount;
        }
    }
}
