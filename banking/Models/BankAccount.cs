using System;
using System.Threading.Tasks;
using banking.Events;

public abstract class BankAccount : ITransaction
{
        public int accountNumber { get; private set; }

        public string customerName { get; private set; }

        protected double balance { get; set; }

        public bool IsActive { get; private set; }

        public event EventHandler<MoneyDepositedEventArgs> MoneyDeposited;
        public event EventHandler<MoneyWithdrawnEventArgs> MoneyWithdrawn;
        public event EventHandler<MoneyTransferredEventArgs> MoneyTransferred;
        public event EventHandler<CloseAccountEventArgs> AccountClosed;

    // Protected raiser methods so derived classes can raise events
    protected virtual void OnMoneyDeposited(MoneyDepositedEventArgs e) =>
        MoneyDeposited?.Invoke(this, e);

    protected virtual void OnMoneyWithdrawn(MoneyWithdrawnEventArgs e) =>
        MoneyWithdrawn?.Invoke(this, e);

    protected virtual void OnMoneyTransferred(MoneyTransferredEventArgs e) =>
        MoneyTransferred?.Invoke(this, e);

    protected virtual void OnAccountClosed(CloseAccountEventArgs e) =>
        AccountClosed?.Invoke(this, e);

        public abstract double CalculateInterest(double interest);

        public BankAccount(
            int accountNumber,
            string customerName,
            double balance)
        {
            if (accountNumber <= 0)
                throw new BankingException("Account number must be greater than zero.");

            if (string.IsNullOrWhiteSpace(customerName))
                throw new BankingException("Customer name cannot be empty.");

            if (balance < 0)
                throw new BankingException("Initial balance cannot be negative.");

            this.accountNumber = accountNumber;
            this.customerName = customerName;
            this.balance = balance;
            IsActive = true;
        }

        public void Deposit(double amount)
        {
            if (!IsActive)
                throw new AccountInactiveException(
                    "Account is inactive.");

            if (amount <= 0)
                throw new InvalidAmountException(
                    "Deposit amount must be greater than zero.");

            balance += amount;

            OnMoneyDeposited(new MoneyDepositedEventArgs(amount));
        }

        public virtual double Withdraw(double amount)
        {
            if (!IsActive)
                throw new AccountInactiveException(
                    "Account is inactive.");

            if (amount <= 0)
                throw new InvalidAmountException(
                    "Withdrawal amount must be greater than zero.");

            if (amount > balance)
                throw new InsufficientBalanceException(
                    "Insufficient balance.");

            balance -= amount;

            OnMoneyWithdrawn(new MoneyWithdrawnEventArgs(amount));

            return balance;
        }

        public void Transfer(BankAccount receiver, double amount)
        {
            if (!IsActive)
                throw new AccountInactiveException(
                    "Sender account is inactive.");

            if (!receiver.IsActive)
                throw new AccountInactiveException(
                    "Receiver account is inactive.");

            if (amount <= 0)
                throw new InvalidAmountException(
                    "Transfer amount must be greater than zero.");

            if (amount > balance)
                throw new InsufficientBalanceException(
                    "Insufficient balance for transfer.");

            Withdraw(amount);

            receiver.Deposit(amount);

            OnMoneyTransferred(new MoneyTransferredEventArgs(
                    accountNumber,
                    receiver.accountNumber,
                    amount));
        }

        public void CloseAccount()
        {
            if (!IsActive)
                throw new AccountInactiveException(
                    "Account is already closed.");

            IsActive = false;

            OnAccountClosed(new CloseAccountEventArgs(
                    accountNumber,
                    customerName));
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Account Number : " + accountNumber);
            Console.WriteLine("Customer Name  : " + customerName);
            Console.WriteLine("Balance        : " + balance);
            Console.WriteLine("Status         : " +
                (IsActive ? "Active" : "Closed"));
            Console.WriteLine("Account Type   : " +
                GetType().Name);
            Console.WriteLine("----------------------------------");
        }

        public async Task<string> GetAccountDetailsAsync()
        {
            await Task.Delay(1000);

            return $"{accountNumber} : {customerName} : {balance}";
        }
    }

