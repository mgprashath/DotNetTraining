namespace BankAccountManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to HNB!");
            try
            {
                BankAccount account = new BankAccount("John Doe", "123456789", 1000.00m, AccountType.Savings);

                account.GetAccountInfo();
                account.Deposit(500.00m);
                account.Withdraw(200.00m);
                account.GetAccountInfo();

                account.Withdraw(2000.00m);
               
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Thank you for banking with HNB!, Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

}


