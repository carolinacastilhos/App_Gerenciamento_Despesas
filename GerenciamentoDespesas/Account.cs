using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDespesas
{
    public class Account
    {
        // propriedades
        public string AccountNumber { get; set; } = null!;
        public string BankBranch { get; set; } = null!;
        [JsonProperty("Balance")]
        public double Balance { get; set; }
        public List<Transactions>? Transactions { get; set; } 

        // construtores
        public Account(string accountNumber, string bankBranch)
        {
            AccountNumber = accountNumber;
            BankBranch = bankBranch;
            Balance = 0.0;
        }

        public Account()
        {

        }

        //adicionando caminho do arquivo json
        private static string _pathAccountsData = @"..\..\..\AccountsData.json";

        // métodos
        public static void AccountManagementMenu()
        {
            
            int option;            

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t -------- Account Management Menu --------\n");
                Console.ResetColor();

                Console.WriteLine("\t1. Register Account");
                Console.WriteLine("\t2. Remove Account");
                Console.WriteLine("\t3. Leave Account Management Menu\n");

                Console.Write("\tEnter your option: ");
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        RegisterAccount();
                        break;
                    case 2:
                        RemoveAccount();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\nYou are leaving Account Management Menu...\n");
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


        public static void RegisterAccount()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t -------- Register Account --------\n");
            Console.ResetColor();

            Console.Write("\n\tWhat is the account number? ");
            string accountNumber = Console.ReadLine()!;
            Console.Write("\n\tWhat is the bank branch? ");
            string bankBranch = Console.ReadLine()!;
            Account account = new Account(accountNumber, bankBranch);

            string jsonAccounts = File.ReadAllText(_pathAccountsData);
            var accountData = JsonConvert.DeserializeObject<List<Account>>(jsonAccounts);          
            if (accountData is not null)
            {
                accountData.Add(account);
            }             
            jsonAccounts = JsonConvert.SerializeObject(accountData);
            File.WriteAllText(_pathAccountsData, jsonAccounts);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAccount successfully registered.");
            Console.ResetColor();
            Print.ShowContinueMessage();
        }

        public static void RemoveAccount()
        {
            Account? account = null;
            string excludeAccountNumber;
            bool accountExists;
            string jsonAccounts;
            List<Account> accounts;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t -------- Remove Account --------\n");
                Console.ResetColor();

                Console.Write("Please, enter the account number: ");
                excludeAccountNumber = Console.ReadLine()!;

                jsonAccounts = File.ReadAllText(_pathAccountsData);
                accounts = JsonConvert.DeserializeObject<List<Account>>(jsonAccounts)!;

                if (string.IsNullOrEmpty(excludeAccountNumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid account number. Please, enter a valid account number.");
                    Console.ResetColor();
                    accountExists = false;
                }
                else
                {
                    account = accounts.FirstOrDefault(p => p.AccountNumber == excludeAccountNumber)!;
                    accountExists = account != null;

                    if (!accountExists)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Account not found! Please, try again.");
                        Console.ResetColor();
                    }
                }

            } while (string.IsNullOrEmpty(excludeAccountNumber) || !accountExists);

            string entry;

            do
            {             
                Console.Write("\nDo you really want to remove the account (Y/N)? ");
                entry = Console.ReadLine()!.ToLower();

                if (entry == "y")
                {
                    accounts.Remove(account);
                    jsonAccounts = JsonConvert.SerializeObject(accounts);
                    File.WriteAllText(_pathAccountsData, jsonAccounts);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAccount removed!\n");
                    Console.ResetColor();
                }
                else if (entry == "n")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAccount not removed!\n");
                    Console.ResetColor();
                }
                else
                {
                    Print.InvalidInputWarning();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\t -------- Remove Account --------\n");
                    Console.ResetColor();
                }

            } while (entry != "y" & entry != "n");

            Print.ShowContinueMessage();
        }
    }
}
