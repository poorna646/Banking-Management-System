class SavingsAccount : BankAccount
{
    public SavingsAccount(
        int accountNumber,
        string customerName,
        double balance)
        : base(accountNumber, customerName, balance)
    {
    }

    public void AddInterest(double interest)
    {
        CalculateInterest(interest);
    }

    public override double CalculateInterest(double interest)
    {
        if (!IsActive)
            throw new AccountInactiveException(
                "Account is inactive.");

        if (interest <= 0)
            throw new InvalidAmountException(
                "Interest must be greater than zero.");

        double interestAmount = balance * interest;

        balance += interestAmount;

        return balance;
    }
}