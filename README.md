# 🏦 Banking Management System — C# Console Application

A **C# console-based Banking Management System** built as a practical project to understand and demonstrate core **C# programming concepts, Object-Oriented Programming, collections, LINQ, delegates, events, exception handling, asynchronous programming, and application design**.

The goal of this project is not only to perform banking operations, but also to show how different C# concepts work together to build a small, structured application.

---

## 📌 Project Overview

The application simulates basic banking operations such as:

* Creating Savings Accounts
* Creating Current Accounts
* Depositing money
* Withdrawing money
* Transferring money between accounts
* Viewing account details
* Viewing all accounts
* Searching accounts
* Calculating interest
* Closing accounts
* Viewing active accounts
* Performing asynchronous account-detail operations

The project follows an object-oriented design where a common `BankAccount` class provides the basic account functionality, while specialized account types such as `SavingsAccount` and `CurrentAccount` implement their own behavior.

---

# 🎯 Why I Built This Project

This project was created to bring together the C# concepts learned individually and understand how they work in a real application.

Instead of learning concepts such as:

```text
Classes
Inheritance
Interfaces
Collections
LINQ
Delegates
Events
Exception Handling
Async/Await
```

independently, this project combines them into one application.

The project therefore acts as a practical demonstration of **C# fundamentals + Object-Oriented Programming + modern C# programming concepts**.

---

# 🛠️ Technologies Used

* **C#**
* **.NET**
* Console Application
* Visual Studio
* Git / GitHub

---

# 🏗️ Application Architecture

The application follows a simple layered structure:

```text
                    Program.cs
                        │
                        ▼
                BankingService
                        │
             ┌──────────┴──────────┐
             ▼                     ▼
       BankAccount             Collections
             │                     │
       ┌─────┴─────┐              LINQ
       ▼           ▼
   Savings      Current
   Account      Account
       │           │
       └─────┬─────┘
             ▼
        Transactions
             │
       ┌─────┼─────────────┐
       ▼     ▼             ▼
    Events  Exceptions   Async/Await
```

### Responsibility of each part

**Program.cs**

Handles user interaction and displays the menu.

**BankingService**

Acts as the service layer and manages all bank accounts and banking operations.

**BankAccount**

Contains common functionality shared by different account types.

**SavingsAccount**

Extends `BankAccount` and provides savings-account-specific behavior.

**CurrentAccount**

Extends `BankAccount` and provides overdraft functionality.

**Exceptions**

Contains custom exceptions for business-related errors.

**Events**

Notify the application when important banking operations occur.

---

# 🧩 C# Concepts Demonstrated

This project intentionally covers a wide range of C# concepts.

---

## 1. Variables and Data Types

The application uses different C# data types such as:

```csharp
int accountNumber;
string customerName;
double balance;
bool IsActive;
```

These represent real-world banking information.

For example:

```csharp
public int accountNumber { get; private set; }

public string customerName { get; private set; }

protected double balance { get; set; }

public bool IsActive { get; private set; }
```

---

# 2. Classes and Objects

A class represents a blueprint for an object.

For example:

```csharp
class BankAccount
{
    ...
}
```

An object is created from that class:

```csharp
BankAccount account;
```

The application creates actual Savings and Current account objects while running.

---

# 3. Constructors

Constructors initialize objects when they are created.

Example:

```csharp
public SavingsAccount(
    int accountNumber,
    string customerName,
    double balance)
    : base(accountNumber, customerName, balance)
{
}
```

The constructor receives the initial account information and passes common information to the base class.

---

# 4. Encapsulation

Encapsulation means controlling how data can be accessed or modified.

For example:

```csharp
public int accountNumber { get; private set; }

public string customerName { get; private set; }

public bool IsActive { get; private set; }
```

Other classes can read these properties but cannot directly modify them.

The balance is protected:

```csharp
protected double balance { get; set; }
```

This allows derived account classes to work with the balance while preventing unrelated classes from directly modifying it.

---

# 5. Access Modifiers

The project demonstrates:

* `public`
* `private`
* `protected`

Example:

```csharp
public bool IsActive { get; private set; }

protected double balance { get; set; }
```

Access modifiers control which parts of the application can access particular members.

---

# 6. Abstraction

`BankAccount` is an abstract class:

```csharp
abstract class BankAccount
```

It represents the common concept of a bank account.

It also contains an abstract method:

```csharp
public abstract double CalculateInterest(double interest);
```

The base class says:

> Every bank account should have a way to calculate interest, but each account type can decide how to implement it.

---

# 7. Inheritance

`SavingsAccount` and `CurrentAccount` inherit from `BankAccount`.

```csharp
class SavingsAccount : BankAccount
```

and:

```csharp
class CurrentAccount : BankAccount
```

This avoids duplicating common account functionality.

The relationship is:

```text
BankAccount
     │
 ┌───┴────────┐
 ▼            ▼
Savings     Current
Account     Account
```

---

# 8. Polymorphism

The application uses method overriding.

For example:

```csharp
public virtual double Withdraw(double amount)
```

in the base class.

`CurrentAccount` overrides it:

```csharp
public override double Withdraw(double amount)
```

This allows different account types to have different withdrawal rules.

For example:

```text
Savings Account
       ↓
Cannot withdraw beyond balance

Current Account
       ↓
Can use overdraft limit
```

---

# 9. Interfaces

The application uses an interface:

```csharp
interface ITransaction
{
    void Deposit(double amount);

    double Withdraw(double amount);

    void Transfer(
        BankAccount receiver,
        double amount);
}
```

`BankAccount` implements it:

```csharp
abstract class BankAccount : ITransaction
```

The interface defines what transaction operations an account should support.

---

# 10. `this` and `base`

The project uses `this` to refer to the current object:

```csharp
this.accountNumber = accountNumber;
```

It also uses `base` to call the parent class constructor:

```csharp
: base(accountNumber, customerName, balance)
```

This demonstrates how constructors work across an inheritance hierarchy.

---

# 11. Collections — List<T>

The banking service stores accounts using:

```csharp
List<BankAccount> accounts =
    new List<BankAccount>();
```

A `List<T>` is useful because the number of bank accounts can grow dynamically.

Accounts are added using:

```csharp
accounts.Add(account);
```

and iterated using:

```csharp
foreach (BankAccount account in accounts)
{
    ...
}
```

---

# 12. Dictionary

Dictionary concepts were also explored while developing the project.

A dictionary stores data as:

```text
Key → Value
```

For example:

```csharp
Dictionary<int, BankAccount>
```

can represent:

```text
Account Number → Bank Account
```

This is useful when fast lookup by account number is required.

---

# 13. HashSet

`HashSet<T>` was also explored as part of the collection concepts.

A HashSet automatically prevents duplicate values.

Example:

```csharp
HashSet<int> accountNumbers =
    new HashSet<int>();
```

This can be useful when unique account numbers or unique values need to be maintained.

---

# 14. LINQ

LINQ is used to search and filter accounts.

For example:

```csharp
var matchingAccounts =
    accounts.Where(
        account =>
            account.customerName
                .Equals(
                    name,
                    StringComparison.OrdinalIgnoreCase));
```

This allows the application to search accounts without manually writing nested loops.

Another example:

```csharp
var activeAccounts =
    accounts.Where(
        account => account.IsActive);
```

LINQ makes collection operations more readable and expressive.

---

# 15. Lambda Expressions

Lambda expressions are used together with LINQ.

Example:

```csharp
account => account.IsActive
```

This means:

> Take an account and return whether that account is active.

Another example:

```csharp
account =>
    account.customerName.Equals(
        name,
        StringComparison.OrdinalIgnoreCase)
```

---

# 16. Delegates

The project demonstrates delegates using:

```csharp
delegate void TransactionHandler(double amount);
```

A delegate represents a reference to a method.

It allows methods to be passed around and invoked through the delegate.

The project also demonstrates the relationship between delegates and events.

---

# 17. Events

Events are used to notify other parts of the application when an important operation occurs.

The account defines events such as:

```csharp
public event EventHandler<MoneyDepositedEventArgs>
    MoneyDeposited;

public event EventHandler<MoneyWithdrawnEventArgs>
    MoneyWithdrawn;

public event EventHandler<MoneyTransferred>
    MoneyTransferred;

public event EventHandler<CloseAccount>
    AccountClosed;
```

For example, after a deposit:

```csharp
MoneyDeposited?.Invoke(
    this,
    new MoneyDepositedEventArgs(amount));
```

The service subscribes to the event:

```csharp
account.MoneyDeposited += NotifyDeposit;
```

The result is:

```text
Deposit
   ↓
MoneyDeposited Event
   ↓
NotifyDeposit()
   ↓
Console notification
```

This demonstrates the publisher/subscriber pattern.

---

# 18. EventHandler and EventArgs

The project uses the standard .NET event pattern.

For example:

```csharp
class MoneyDepositedEventArgs : EventArgs
{
    public double Amount { get; }

    public MoneyDepositedEventArgs(double amount)
    {
        Amount = amount;
    }
}
```

`EventArgs` is used to carry additional information about an event.

For example:

```text
MoneyDeposited
      ↓
Amount
```

The event subscriber can access that amount through the event arguments.

---

# 19. Exception Handling

The application uses exception handling to prevent unexpected failures from crashing the application.

The main program contains:

```csharp
try
{
    ...
}
catch (BankingException ex)
{
    ...
}
catch (FormatException)
{
    ...
}
catch (Exception ex)
{
    ...
}
```

This demonstrates multiple catch blocks.

---

# 20. Custom Exceptions

The project defines custom exceptions such as:

```csharp
BankingException
AccountNotFoundException
AccountInactiveException
InvalidAmountException
InsufficientBalanceException
```

For example:

```csharp
throw new AccountNotFoundException(
    "Account not found.");
```

This makes business errors more meaningful than generic exceptions.

---

# 21. Exception Inheritance

The custom exceptions demonstrate inheritance:

```text
Exception
   │
   ▼
BankingException
   │
   ├── AccountNotFoundException
   ├── AccountInactiveException
   ├── InvalidAmountException
   └── InsufficientBalanceException
```

This allows all banking-related exceptions to be handled together:

```csharp
catch (BankingException ex)
{
    Console.WriteLine(ex.Message);
}
```

---

# 22. Inner Exceptions

The custom `BankingException` also supports an inner exception:

```csharp
public BankingException(
    string message,
    Exception innerException)
    : base(message, innerException)
{
}
```

An inner exception allows the original exception to be preserved while providing a higher-level application message.

Conceptually:

```text
Application Error
       ↓
BankingException
       ↓
Original Exception
```

---

# 23. `throw` vs `throw ex`

The project also covers an important exception-handling concept.

Prefer:

```csharp
throw;
```

instead of:

```csharp
throw ex;
```

`throw;` preserves the original stack trace.

This is important when debugging applications.

---

# 24. `async` / `await`

The application demonstrates asynchronous programming.

Example:

```csharp
public async Task<string> GetAccountDetailsAsync()
{
    await Task.Delay(1000);

    return $"{accountNumber} : {customerName} : {balance}";
}
```

The service can asynchronously retrieve account details:

```csharp
public async Task DisplayAccountsAsync()
{
    foreach (BankAccount account in accounts)
    {
        string details =
            await account.GetAccountDetailsAsync();

        Console.WriteLine(details);
    }
}
```

This introduces the basic concept of asynchronous execution in C#.

---

# 25. `Task`

The asynchronous methods return:

```csharp
Task
```

or:

```csharp
Task<string>
```

A `Task` represents an operation that may complete in the future.

---

# 26. LINQ + Lambda + Collections Together

One of the important goals of this project is showing how different C# concepts work together.

For example:

```csharp
var activeAccounts =
    accounts.Where(
        account => account.IsActive);
```

Here we are using:

```text
List<T>
  +
LINQ
  +
Lambda Expression
```

in a single operation.

---

# 27. Method Overriding

`CurrentAccount` overrides the withdrawal behavior:

```csharp
public override double Withdraw(double amount)
```

The base account has one withdrawal rule, while the current account has another because it supports overdraft.

This demonstrates runtime polymorphism.

---

# 28. `virtual` and `override`

The base class defines:

```csharp
public virtual double Withdraw(double amount)
```

and the derived class uses:

```csharp
public override double Withdraw(double amount)
```

This allows derived classes to provide specialized behavior.

---

# 29. Null Checking

The application checks whether an account exists before performing operations.

For example:

```csharp
BankAccount account =
    FindAccount(accountNumber);

if (account == null)
{
    throw new AccountNotFoundException(
        "Account not found.");
}
```

This prevents operations from being performed on a non-existent account.

---

# 30. String Handling

The application uses string operations such as:

```csharp
string.IsNullOrWhiteSpace()
```

and:

```csharp
Equals(
    name,
    StringComparison.OrdinalIgnoreCase)
```

This allows customer names to be searched without requiring exact letter casing.

---

# 💰 Banking Operations

The application supports the following operations.

### Create Savings Account

```text
Account Number
Customer Name
Initial Balance
```

### Create Current Account

```text
Account Number
Customer Name
Initial Balance
Overdraft Limit
```

### Deposit

```text
Account Number
Amount
      ↓
Balance increases
      ↓
MoneyDeposited event
```

### Withdraw

```text
Account Number
Amount
      ↓
Validation
      ↓
Balance decreases
      ↓
MoneyWithdrawn event
```

### Transfer

```text
Sender Account
       ↓
Validate
       ↓
Withdraw
       ↓
Receiver Account
       ↓
Deposit
       ↓
MoneyTransferred event
```

### Close Account

```text
Account
   ↓
IsActive = false
   ↓
AccountClosed event
```

---

# 🔐 Business Rules

The application validates important banking operations.

### Deposit

* Amount must be greater than zero.
* Account must be active.

### Withdrawal

* Amount must be greater than zero.
* Account must be active.
* Savings account cannot exceed available balance.

### Current Account

Current accounts can use:

```text
Balance + Overdraft Limit
```

for withdrawal.

### Transfer

* Sender must exist.
* Receiver must exist.
* Sender and receiver cannot be the same.
* Both accounts must be active.
* Transfer amount must be valid.
* Sender must have sufficient available funds.

### Account Closing

* Account must exist.
* Account cannot already be closed.

---

# 📂 Project Structure

```text
BankingApplication/
│
├── Program.cs
│
├── BankingService.cs
│
├── BankAccount.cs
├── SavingsAccount.cs
├── CurrentAccount.cs
│
├── ITransaction.cs
├── TransactionHandler.cs
│
├── MoneyDepositedEventArgs.cs
├── MoneyWithdrawnEventArgs.cs
├── MoneyTransferred.cs
├── CloseAccount.cs
│
└── Exceptions/
    ├── BankingException.cs
    ├── AccountNotFoundException.cs
    ├── AccountInactiveException.cs
    ├── InvalidAmountException.cs
    └── InsufficientBalanceException.cs
```

---

# 🔄 Application Flow

The overall application flow is:

```text
User
 │
 ▼
Program.cs
 │
 ▼
Menu Selection
 │
 ▼
BankingService
 │
 ├── Create Account
 ├── Deposit
 ├── Withdraw
 ├── Transfer
 ├── Search
 ├── Calculate Interest
 └── Close Account
 │
 ▼
BankAccount
 │
 ├── SavingsAccount
 └── CurrentAccount
 │
 ├── Events
 ├── Exceptions
 ├── Collections
 ├── LINQ
 └── Async/Await
```

---

# 🧠 Key OOP Concepts Used

The project demonstrates the four major pillars of Object-Oriented Programming:

| OOP Concept   | Implementation                     |
| ------------- | ---------------------------------- |
| Encapsulation | Properties and access modifiers    |
| Abstraction   | `abstract BankAccount`             |
| Inheritance   | `SavingsAccount`, `CurrentAccount` |
| Polymorphism  | `virtual` / `override` methods     |

---

# 🧪 Example Scenario

Suppose we create:

```text
Savings Account
Account Number: 101
Customer: Poornashree
Balance: ₹10,000
```

and:

```text
Current Account
Account Number: 102
Customer: Shree
Balance: ₹5,000
Overdraft: ₹2,000
```

If ₹2,000 is transferred:

```text
Account 101
₹10,000
    │
    │ ₹2,000
    ▼
Account 102
₹7,000
```

During this operation:

```text
Transfer()
    ↓
Withdraw()
    ↓
Deposit()
    ↓
MoneyTransferred Event
    ↓
Notification
```

This single operation demonstrates multiple C# concepts working together.

---

# 🚀 How to Run

### 1. Clone the repository

```bash
git clone <your-repository-url>
```

### 2. Open the project

Open the project using:

* Visual Studio
* Visual Studio Code

### 3. Build

```bash
dotnet build
```

### 4. Run

```bash
dotnet run
```

---

# 📚 What This Project Demonstrates

By completing this project, the following C# concepts are demonstrated:

```text
✓ Variables and Data Types
✓ Operators
✓ Conditional Statements
✓ Loops
✓ Methods
✓ Classes and Objects
✓ Constructors
✓ this keyword
✓ static concepts
✓ Access Modifiers
✓ Encapsulation
✓ Properties
✓ Inheritance
✓ Abstraction
✓ Interfaces
✓ Polymorphism
✓ Method Overloading / Overriding concepts
✓ virtual / override
✓ Collections
✓ List<T>
✓ Dictionary<TKey,TValue>
✓ HashSet<T>
✓ Generics
✓ Lambda Expressions
✓ LINQ
✓ Delegates
✓ Events
✓ EventHandler
✓ EventArgs
✓ Custom Exceptions
✓ Multiple Catch Blocks
✓ Inner Exceptions
✓ throw / throw ex concepts
✓ async / await
✓ Task
✓ String Handling
✓ Null Handling
✓ Console Application Design
```

---

# 🎓 Learning Outcome

The main learning outcome from this project is understanding that C# concepts are not isolated.

A real application combines them.

For example:

```text
OOP
 ↓
BankAccount
 ↓
Inheritance
 ↓
Savings / Current
 ↓
Collections
 ↓
List<BankAccount>
 ↓
LINQ
 ↓
Search / Filter
 ↓
Events
 ↓
Transaction Notifications
 ↓
Exceptions
 ↓
Business Validation
 ↓
Async/Await
 ↓
Asynchronous Operations
```

This project therefore provides a practical foundation before moving into **.NET and ASP.NET Core Web API development**.

---

# 🔮 Future Improvements

Possible future enhancements include:

* Database integration using SQL Server
* Entity Framework Core
* ASP.NET Core Web API
* REST APIs
* Authentication and authorization
* Dependency Injection
* Repository / Service patterns
* Unit testing using xUnit or NUnit
* Logging
* Global exception handling
* DTOs
* Swagger/OpenAPI
* Frontend integration
* Docker
* CI/CD

The current console application can therefore serve as a starting point for converting the system into a real backend application.

---

# 👩‍💻 Author

Built as a practical C# learning and portfolio project to strengthen understanding of **Object-Oriented Programming, C# fundamentals, and application development**.

---

## ⭐ If you found this project useful

Feel free to explore the code and suggest improvements.
