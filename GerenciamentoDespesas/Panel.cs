using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDespesas
{
    public class Panel
    {
        private static string _pathAccountsData = @"C:\Users\carol\OneDrive\Área de Trabalho\Desafio It Academy\GerenciamentoDespesas\GerenciamentoDespesas\AccountsData.json";

        public static void DetailsAccount()
        {
            //Resumo das contas: listar cada conta e seu saldo atual, bem como o saldo
            //total do usuário(considerando todas as suas contas);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t -------- Accounts' Details --------\n");
            Console.ResetColor();

            string jsonAccounts = File.ReadAllText(_pathAccountsData);
            List<Dictionary<string, string>> accounts = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonAccounts)!;
           
            if (accounts.Count > 0)
            {
                int i = 1;
                double sum = 0;
                
                    foreach (var item in accounts)
                    {
                        string accountValueKey = "AccountNumber";
                        string accountValue = item[accountValueKey];
                        string branchValueKey = "BankBranch";
                        string branchvalue = item[branchValueKey];
                        string balanceValueKey = "Balance";
                        double balanceValue = double.Parse(item[balanceValueKey]);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($" {i} Account: ");
                        Console.ResetColor();
                        Console.WriteLine($"Number: {accountValue} | Bank Branch: {branchvalue} | Balance: {balanceValue}\n");
                        i++;
                        sum += balanceValue;
                    }

                Console.WriteLine($"Total balance: {sum}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere are no accounts to show.\n");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n< Press any key to return to Main Menu");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}
