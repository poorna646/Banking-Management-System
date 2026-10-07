namespace banking.Events
{
    public class CloseAccountEventArgs : EventArgs
    {
        public int AccountNumber { get; }

        public string CustomerName { get; }

        public CloseAccountEventArgs(
            int accountNumber,
            string customerName)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
        }
    }
}
