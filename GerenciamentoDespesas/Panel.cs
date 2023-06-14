using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDespesas
{
    public class Panel
    {
        private static string _pathAccountsData = @"..\..\..\AccountsData.json";

        public static void DetailsAccount()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t -------- Accounts' Details --------\n");
            Console.ResetColor();


            string jsonAccounts = File.ReadAllText(_pathAccountsData);
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(jsonAccounts)!;

            if (accounts != null && accounts.Count > 0)
            {
                int i = 1;
                double sum = 0;
                foreach (var account in accounts)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{i}. Account:");
                    Console.ResetColor();
                    Console.WriteLine($"Number: {account.AccountNumber} | Bank Branch: {account.BankBranch} | Balance: {account.Balance.ToString("C2", new CultureInfo("pt-BR"))}\n");
                    i++;
                    sum += account.Balance;
                }

                Console.WriteLine($"Total balance: {sum.ToString("C2", new CultureInfo("pt-BR"))}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere are no accounts to show.\n");
                Console.ResetColor();
            }
            /*
            //var filteredJson = jsonAccounts.Replace("\"Transactions\":null", "\"Transactions\":[]");
            string jsonAccounts = File.ReadAllText(_pathAccountsData);
            //List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(filteredJson)!;
            List<Dictionary<string, string>> accounts = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonAccounts)!;

            if (accounts != null && accounts.Count > 0)
            {
                int i = 1;
                double sum = 0;
                foreach (var item in accounts)
                {
                    if (item.TryGetValue("AccountNumber", out string? accountValue) &&
                        item.TryGetValue("BankBranch", out string? branchValue) &&
                        item.TryGetValue("Balance", out string? balanceValueStr) &&
                        double.TryParse(balanceValueStr, out double balanceValue))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"{i}. Account:");
                        Console.ResetColor();
                        Console.WriteLine($"Number: {accountValue} | Bank Branch: {branchValue} | Balance: {balanceValue}\n");
                        i++;
                        sum += balanceValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid account entry.");
                    }
                }

                Console.WriteLine($"Total balance: {sum}");
            }            
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere are no accounts to show.\n");
                Console.ResetColor();
            }*/

            Print.ShowContinueMessage();
        }
    }
}
