using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
        public double Balance { get; set; }
       
        // construtores
        public Account(string accountNumber, string bankBranch)
        {
            AccountNumber = accountNumber;
            BankBranch = bankBranch;
            Balance = 0;
        }

        public Account()
        {

        }

        //adicionando caminho do arquivo json
        private static string _pathAccountsData = @"C:\Users\carol\OneDrive\Área de Trabalho\Desafio It Academy\GerenciamentoDespesas\GerenciamentoDespesas\AccountsData.json";

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
                Console.WriteLine("\t3. Merge Accounts");
                Console.WriteLine("\t4. Leave Account Management Menu\n");

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
                        //MergeAccounts();
                        break;
                    case 4:
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
            while (option != 4);
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
            string entry = "n";
            Dictionary<string, string> indexToExclude;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\t -------- Remove Account --------\n");
                Console.ResetColor();
                Console.Write("Type the number account: ");
                string numberToExclude = Console.ReadLine()!;

                string jsonAccounts = File.ReadAllText(_pathAccountsData);
                List<Dictionary<string, string>> accounts = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonAccounts)!;
                indexToExclude = accounts.Find(d => d["AccountNumber"] == numberToExclude)!;                        
                
                if (indexToExclude == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("Account number not found. Would you like to try again (Y/N)? ");
                    Console.ResetColor();
                    entry = Console.ReadLine().ToLower();
                    Console.WriteLine();                    
                    Console.Clear();

                    if (entry != "y" & entry != "n")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nWrong code. Would you like to try again (Y/N)?\n");
                        Console.ResetColor();
                        entry = Console.ReadLine().ToLower();
                        Console.WriteLine();                        
                        Console.Clear();
                    }                    
                }
                else
                {                   
                        Console.Write("\nDeseja realmente excluir a conta (Y/N)? ");
                        string entrada = Console.ReadLine().ToLower();

                        if (entrada == "y")
                        {
                            accounts.Remove(indexToExclude);
                            jsonAccounts = JsonConvert.SerializeObject(accounts);
                            File.WriteAllText(_pathAccountsData, jsonAccounts);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nAccount removed!\n");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            entry = "n";
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nAccount not removed!\n");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            entry = "n";
                        }                                        
                }
            }
            while (entry == "y");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t -------- Remove Account --------\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n< Press any key to return to Account Management Menu");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
       }    

        public static void MergeAccounts()
        {

        }
    }
}
