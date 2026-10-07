using System;

class Program
{
    static async Task Main(string[] args)
    {
        BankingService service = new BankingService();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("       BANKING MANAGEMENT SYSTEM");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Create Savings Account");
            Console.WriteLine("2. Create Current Account");
            Console.WriteLine("3. Deposit Money");
            Console.WriteLine("4. Withdraw Money");
            Console.WriteLine("5. Transfer Money");
            Console.WriteLine("6. View Account");
            Console.WriteLine("7. View All Accounts");
            Console.WriteLine("8. Search Account");
            Console.WriteLine("9. Calculate Interest");
            Console.WriteLine("10. Close Account");
            Console.WriteLine("11. View Active Accounts");
            Console.WriteLine("12. Async Account Details");
            Console.WriteLine("13. Exit");
            Console.Write("\nEnter your choice: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        service.CreateSavingsAccount();
                        break;

                    case 2:
                        service.CreateCurrentAccount();
                        break;

                    case 3:
                        Console.Write("Enter account number: ");
                        int depositAccount = int.Parse(Console.ReadLine());

                        Console.Write("Enter amount to deposit: ");
                        double depositAmount = double.Parse(Console.ReadLine());

                        service.DepositMoney(depositAccount, depositAmount);
                        break;

                    case 4:
                        Console.Write("Enter account number: ");
                        int withdrawAccount = int.Parse(Console.ReadLine());

                        Console.Write("Enter amount to withdraw: ");
                        double withdrawAmount = double.Parse(Console.ReadLine());

                        service.WithdrawMoney(withdrawAccount, withdrawAmount);
                        break;

                    case 5:
                        Console.Write("Enter sender account number: ");
                        int senderAccount = int.Parse(Console.ReadLine());

                        Console.Write("Enter receiver account number: ");
                        int receiverAccount = int.Parse(Console.ReadLine());

                        Console.Write("Enter amount to transfer: ");
                        double transferAmount = double.Parse(Console.ReadLine());

                        service.TransferMoney(
                            senderAccount,
                            receiverAccount,
                            transferAmount);

                        break;

                    case 6:
                        Console.Write("Enter account number: ");
                        int viewAccount = int.Parse(Console.ReadLine());

                        service.ViewAccount(viewAccount);
                        break;

                    case 7:
                        service.ViewAllAccounts();
                        break;

                    case 8:
                        Console.Write("Enter customer name: ");
                        string name = Console.ReadLine();

                        service.SearchAccounts(name);
                        break;

                    case 9:
                        Console.Write("Enter account number: ");
                        int interestAccount = int.Parse(Console.ReadLine());

                        Console.Write("Enter interest rate: ");
                        double interest = double.Parse(Console.ReadLine());

                        service.CalculateInterest(
                            interestAccount,
                            interest);

                        break;

                    case 10:
                        Console.Write("Enter account number: ");
                        int closeAccount = int.Parse(Console.ReadLine());

                        service.CloseAccount(closeAccount);
                        break;

                    case 11:
                        service.ViewActiveAccounts();
                        break;

                    case 12:
                        await service.DisplayAccountsAsync();
                        break;

                    case 13:
                        Console.WriteLine("Thank you!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (BankingException ex)
            {
                Console.WriteLine("Banking Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid input.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}