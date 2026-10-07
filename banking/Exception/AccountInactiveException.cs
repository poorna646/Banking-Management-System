class AccountInactiveException : BankingException
{
    public AccountInactiveException(string message)
        : base(message)
    {
    }
}