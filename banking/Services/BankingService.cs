using System.Linq;
using banking.Events;

class BankingService
{
    private List<BankAccount> accounts =
        new List<BankAccount>();

    private static void NotifyDeposit(
        object sender,
        MoneyDepositedEventArgs e)
    {
        Console.WriteLine(
            $"[EVENT] Amount deposited successfully: Rs.{e.Amount}");
    }

    private static void NotifyWithdrawn(
        object sender,
        MoneyWithdrawnEventArgs e)
    {
        Console.WriteLine(
            $"[EVENT] Amount withdrawn successfully: Rs.{e.Amount}");
    }

    private static void NotifyTransfer(
        object sender,
        MoneyTransferredEventArgs e)
    {
        Console.WriteLine(
            $"[EVENT] Amount transferred successfully: Rs.{e.Amount}");
        Console.WriteLine(
            $"From: {e.SenderAccountNumber} → " +
            $"To: {e.ReceiverAccountNumber}");
    }

    private static void NotifyAccountClosed(
        object sender,
        CloseAccountEventArgs e)
    {
        Console.WriteLine(
            $"[EVENT] Account {e.AccountNumber} " +
            $"({e.CustomerName}) closed successfully.");
    }

    public void CreateSavingsAccount()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();

        Console.Write("Enter initial balance: ");
        double balance = double.Parse(Console.ReadLine());

        if (FindAccount(accountNumber) != null)
            throw new BankingException(
                "Account number already exists.");

        SavingsAccount account =
            new SavingsAccount(
                accountNumber,
                customerName,
                balance);

        SubscribeToEvents(account);

        accounts.Add(account);

        Console.WriteLine(
            "Savings account created successfully!");
    }

    public void CreateCurrentAccount()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter customer name: ");
        string customerName = Console.ReadLine();

        Console.Write("Enter initial balance: ");
        double balance = double.Parse(Console.ReadLine());

        Console.Write("Enter overdraft limit: ");
        double overdraftLimit =
            double.Parse(Console.ReadLine());

        if (FindAccount(accountNumber) != null)
            throw new BankingException(
                "Account number already exists.");

        CurrentAccount account =
            new CurrentAccount(
                accountNumber,
                customerName,
                balance,
                overdraftLimit);

        SubscribeToEvents(account);

        accounts.Add(account);

        Console.WriteLine(
            "Current account created successfully!");
    }

    private void SubscribeToEvents(BankAccount account)
    {
        account.MoneyDeposited += NotifyDeposit;
        account.MoneyWithdrawn += NotifyWithdrawn;
        account.MoneyTransferred += NotifyTransfer;
        account.AccountClosed += NotifyAccountClosed;
    }

    public BankAccount FindAccount(int accountNumber)
    {
        return accounts.FirstOrDefault(
            account =>
                account.accountNumber == accountNumber);
    }

    public void DepositMoney(
        int accountNumber,
        double amount)
    {
        BankAccount account =
            FindAccount(accountNumber);

        if (account == null)
            throw new AccountNotFoundException(
                "Account not found.");

        account.Deposit(amount);
    }

    public void WithdrawMoney(
        int accountNumber,
        double amount)
    {
        BankAccount account =
            FindAccount(accountNumber);

        if (account == null)
            throw new AccountNotFoundException(
                "Account not found.");

        account.Withdraw(amount);
    }

    public void TransferMoney(
        int senderAccountNumber,
        int receiverAccountNumber,
        double amount)
    {
        if (senderAccountNumber ==
            receiverAccountNumber)
        {
            throw new BankingException(
                "Sender and receiver cannot be the same.");
        }

        BankAccount sender =
            FindAccount(senderAccountNumber);

        BankAccount receiver =
            FindAccount(receiverAccountNumber);

        if (sender == null ||
            receiver == null)
        {
            throw new AccountNotFoundException(
                "Sender or receiver account not found.");
        }

        sender.Transfer(receiver, amount);
    }

    public void CloseAccount(int accountNumber)
    {
        BankAccount account =
            FindAccount(accountNumber);

        if (account == null)
            throw new AccountNotFoundException(
                "Account not found.");

        account.CloseAccount();
    }

    public void ViewAccount(int accountNumber)
    {
        BankAccount account =
            FindAccount(accountNumber);

        if (account == null)
            throw new AccountNotFoundException(
                "Account not found.");

        account.DisplayAccountDetails();
    }

    public void ViewAllAccounts()
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine(
                "No accounts available.");

            return;
        }

        foreach (BankAccount account in accounts)
        {
            account.DisplayAccountDetails();
        }
    }

    public void SearchAccounts(string name)
    {
        var matchingAccounts =
            accounts.Where(
                account =>
                    account.customerName
                        .Equals(
                            name,
                            StringComparison.OrdinalIgnoreCase));

        if (!matchingAccounts.Any())
        {
            Console.WriteLine(
                "No matching accounts found.");

            return;
        }

        foreach (BankAccount account in matchingAccounts)
        {
            account.DisplayAccountDetails();
        }
    }

    public void CalculateInterest(
        int accountNumber,
        double interest)
    {
        BankAccount account =
            FindAccount(accountNumber);

        if (account == null)
            throw new AccountNotFoundException(
                "Account not found.");

        account.CalculateInterest(interest);

        Console.WriteLine(
            "Interest calculated successfully.");
    }

    public void ViewActiveAccounts()
    {
        var activeAccounts =
            accounts.Where(
                account => account.IsActive);

        foreach (BankAccount account in activeAccounts)
        {
            account.DisplayAccountDetails();
        }
    }

    public async Task DisplayAccountsAsync()
    {
        Console.WriteLine(
            "Fetching account details asynchronously...");

        foreach (BankAccount account in accounts)
        {
            string details =
                await account.GetAccountDetailsAsync();

            Console.WriteLine(details);
        }
    }
}