class InsufficientBalanceException : BankingException
{
    public InsufficientBalanceException(string message)
        : base(message)
    {
    }
}