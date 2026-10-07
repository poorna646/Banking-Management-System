interface ITransaction
{
    void Deposit(double amount);

    double Withdraw(double amount);

    void Transfer(
        BankAccount receiver,
        double amount);
}