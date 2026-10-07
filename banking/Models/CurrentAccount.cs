using banking.Events;

class CurrentAccount : BankAccount
{
    public double OverdraftLimit { get; private set; }

    public CurrentAccount(
        int accountNumber,
        string customerName,
        double balance,
        double overdraftLimit)
        : base(accountNumber, customerName, balance)
    {
        if (overdraftLimit < 0)
            throw new BankingException(
                "Overdraft limit cannot be negative.");

        OverdraftLimit = overdraftLimit;
    }

    public override double Withdraw(double amount)
    {
        if (!IsActive)
            throw new AccountInactiveException(
                "Account is inactive.");

        if (amount <= 0)
            throw new InvalidAmountException(
                "Withdrawal amount must be greater than zero.");

        if (amount > balance + OverdraftLimit)
            throw new InsufficientBalanceException(
                "Withdrawal exceeds overdraft limit.");

        balance -= amount;

        OnMoneyWithdrawn(new MoneyWithdrawnEventArgs(amount));

        return balance;
    }

    public override double CalculateInterest(double interest)
    {
        if (!IsActive)
            throw new AccountInactiveException(
                "Account is inactive.");

        double interestAmount = balance * interest;

        balance += interestAmount;

        return balance;
    }

    public new void DisplayAccountDetails()
    {
        base.DisplayAccountDetails();

        Console.WriteLine(
            "Overdraft Limit: " + OverdraftLimit);
    }
}