using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagement
{
    // Enum for the type of account, defining possible account types
    public enum AccountType
    {
        Savings,
        Current,
        Capital
    }
    public class BankAccount
    {
        // String for the account holders full name. 
        public string AccountHolder { get; set; }
        // String for the account number. While it may contain only digits, handles leading zeros.
        // often treated as a sequence of characters
        public string AccountNumber { get; set; }
        // Decimal for the current balance of the account. Decimal is the most appropriate
        // type for financial calculations due to its precision with base-10 numbers.
        // this minimize rounding errors that are common with float and double
        // private set to prevent direct external modification
        public decimal Balance { get; private set; }

        // Enum for the type of account (Savings, Current, Capital). An enum is preferred here as it restricts
        // the account type to predefined values, enhancing code readability and reducing errors.
        public AccountType Type { get; set; }

        public BankAccount(string accountHolder, string accountNumber, decimal initialBalance, AccountType accountType )
        {
            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
            Balance = initialBalance;
            Type = accountType;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            Balance -= amount;
        }

        public void GetAccountInfo()
        {
            Console.WriteLine("----- Account Information -----");
            Console.WriteLine($"Account Holder: {AccountHolder}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Type: {Type}");
            Console.WriteLine($"Current Balance: {Balance:C}");
            Console.WriteLine("---------------------------");
        }
    }
}
