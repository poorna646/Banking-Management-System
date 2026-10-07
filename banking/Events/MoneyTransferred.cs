namespace banking.Events
{
    public class MoneyTransferredEventArgs : EventArgs
    {
        public double Amount { get; }

        public int SenderAccountNumber { get; }

        public int ReceiverAccountNumber { get; }

        public MoneyTransferredEventArgs(
            int senderAccountNumber,
            int receiverAccountNumber,
            double amount)
        {
            SenderAccountNumber = senderAccountNumber;
            ReceiverAccountNumber = receiverAccountNumber;
            Amount = amount;
        }
    }
}
