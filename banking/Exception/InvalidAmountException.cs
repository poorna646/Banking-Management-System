class InvalidAmountException : BankingException
{
    public InvalidAmountException(string message)
        : base(message)
    {
    }
}