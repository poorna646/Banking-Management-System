class AccountNotFoundException : BankingException
{
    public AccountNotFoundException(string message)
        : base(message)
    {
    }
}