using GerenciamentoDespesas;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GerenciamentoDespesas
{
    public class Transactions
    {
        public string Date { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Value { get; set; }

        public Transactions (string date, string type, string category, string description, double value)
        {
            Date = date;
            Type = type;
            Category = category;
            Description = description;
            Value = value;
        }

        public Transactions ()
        {

        }

        private static string _pathAccountsData = @"..\..\..\AccountsData.json";

        public static void TransactionsMenu()
        {

            int option;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t -------- Transactions Menu --------\n");
                Console.ResetColor();

                Console.WriteLine("\t1. Include a Transaction");
                Console.WriteLine("\t2. Show all Transactions of an Account");
                Console.WriteLine("\t3. Leave Transactions Menu\n");

                Console.Write("\tEnter your option: ");
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        IncludeTransaction();
                        break;
                    case 2:
                        ShowTransactions();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nYou are leaving Transactions Menu...\n");
                        Console.ResetColor();
                        Print.ShowContinueMessage();
                        break;
                    default:
                        Print.InvalidInputWarning();
                        break;
                }
            }
            while (option != 3);
        }

        public static void IncludeTransaction()
        {
            bool endOfTransaction = false;
            Account? account = null; 

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t -------- Including Transaction --------\n");
                Console.ResetColor();

                string transAccountNumber;
                bool accountExists;
                string jsonAccounts;
                List<Account> accounts;

                do
                {
                    Console.Write("Please, enter the account number of the transaction: ");
                    transAccountNumber = Console.ReadLine()!;

                    jsonAccounts = File.ReadAllText(_pathAccountsData);
                    accounts = JsonConvert.DeserializeObject<List<Account>>(jsonAccounts)!;

                    if (string.IsNullOrEmpty(transAccountNumber))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid account number. Please, enter a valid account number.");
                        Console.ResetColor();
                        accountExists = false;
                    }
                    else
                    {
                        account = accounts.FirstOrDefault(p => p.AccountNumber == transAccountNumber)!;
                        accountExists = account != null;

                        if (!accountExists)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Account not found! Please, try again.");
                            Console.ResetColor();
                        }
                    }

                } while (string.IsNullOrEmpty(transAccountNumber) || !accountExists);

                string type;

                do
                {
                    Console.Write("Type of the transaction (income or expense): ");
                    type = Console.ReadLine()!.ToLower();

                    if (type != "income" && type != "expense")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid transaction type. Please, enter 'income' or 'expense'.");
                        Console.ResetColor();
                    }

                } while (type != "income" && type != "expense");


                string date;

                do
                {
                    Console.Write("Date of the transaction (dd/mm/yyyy): ");
                    date = Console.ReadLine()!;

                    if (!DateTime.TryParseExact(date, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid date format. Please, enter the date in the format dd/mm/yyyy.");
                        Console.ResetColor();
                    }

                } while (!DateTime.TryParseExact(date, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _));



                Console.Write("Category of the transaction (food, wage, home...): ");
                string category = Console.ReadLine()!;

                Console.Write("Description of the transaction: ");
                string description = Console.ReadLine()!;

                string valueInput;
                double value;

                do
                {
                    Console.Write("Value: ");
                    valueInput = Console.ReadLine()!;

                    if (!double.TryParse(valueInput, NumberStyles.Number, CultureInfo.InvariantCulture, out value) || value <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid value. Please, enter a numeric value greater than 0.");
                        Console.ResetColor();
                    }

                } while (!double.TryParse(valueInput, NumberStyles.Number, CultureInfo.InvariantCulture, out value) || value <= 0);

                if (account != null)
                {
                    if (account.Transactions == null)
                    {
                        account.Transactions = new List<Transactions>();
                    }

                    Transactions transaction = new Transactions(date, type, category, description, value);
                    account.Transactions.Add(transaction);

                    if (type == "income")
                    {
                        account.Balance += transaction.Value;
                    }

                    if (type == "expense")
                    {
                        account.Balance -= transaction.Value;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nTransaction added to the account and balance updated!");
                    Console.ResetColor();
                    endOfTransaction = true;
                    jsonAccounts = JsonConvert.SerializeObject(accounts);
                    File.WriteAllText(_pathAccountsData, jsonAccounts);
                    Print.ShowContinueMessage();
                }

            } while (endOfTransaction == false) ;
             
        }

        public static void ShowTransactions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t -------- Showing Transactions --------\n");
            Console.ResetColor();

            string transAccountNumber;
            string jsonAccounts;
            List<Account> accounts;

            jsonAccounts = File.ReadAllText(_pathAccountsData);
            accounts = JsonConvert.DeserializeObject<List<Account>>(jsonAccounts)!;

            do
            {
                Console.Write("Please, enter the account number: ");
                transAccountNumber = Console.ReadLine()!;

                if (string.IsNullOrEmpty(transAccountNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid account number. Please, enter a valid account number.");
                    Console.ResetColor();
                }
                else
                {
                    var account = accounts.FirstOrDefault(p => p.AccountNumber == transAccountNumber);

                    if (account == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Account not found! Please, try again.");
                        Console.ResetColor();
                    }
                    else if (account.Transactions?.Count > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nTransactions for Account: " + account.AccountNumber);
                        Console.WriteLine("------------------------------\n");
                        Console.ResetColor();

                        foreach (Transactions transaction in account.Transactions)
                        {
                            Console.WriteLine("Date: " + transaction.Date);
                            Console.WriteLine("Type: " + transaction.Type);
                            Console.WriteLine("Category: " + transaction.Category);
                            Console.WriteLine("Description: " + transaction.Description);
                            Console.WriteLine("Value: " + transaction.Value.ToString("C2", new CultureInfo("pt-BR")));
                            Console.WriteLine("------------------------------\n");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No transactions found for Account: " + account.AccountNumber);
                        Console.ResetColor();
                    }
                }
            } while (string.IsNullOrEmpty(transAccountNumber));

            Print.ShowContinueMessage();
        }

    }
}

