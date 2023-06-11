using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

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

        private static string _pathAccountsData = @"C:\Users\carol\OneDrive\Área de Trabalho\Desafio It Academy\GerenciamentoDespesas\GerenciamentoDespesas\AccountsData.json";

        public static void IncludeTransaction()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t -------- Including Transaction --------\n");
            Console.ResetColor();

            Console.Write("Please, entry the account number of the transaction: ");
            string transAccountNumber = Console.ReadLine()!;
            Console.Write("Now, entry the type of the transaction (income or expense): ");
            string type = Console.ReadLine()!;
            Console.Write("Entry the date of the transaction (dd/mm/yyyy): ");
            string date = Console.ReadLine()!;
            Console.Write("Entry the category of the transaction (food, wage, home...): ");
            string category = Console.ReadLine()!;
            Console.Write("Entry a description: ");
            string description = Console.ReadLine()!;
            Console.Write("Entry the value of the transaction: ");
            double value = double.Parse(Console.ReadLine()!);

            //Transactions transaction = new Transactions(date, type, category, description, value);

            /*string[] transaction = new string[5];
            transaction[0] = type;
            transaction[1] = date;
            transaction[2] = category;
            transaction[3] = description;
            transaction[4] = value.ToString();*/

            string nameKey = "Transaction";

            string jsonAccounts = File.ReadAllText(_pathAccountsData);
            List<Dictionary<string, string>> accounts = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonAccounts)!;

            if (accounts is not null)
            { 
                foreach (var item in accounts) 
                {
                    string accountNumber = "AccountNumber";
                    string accountValue = item[accountNumber];                    

                    if (accountValue == transAccountNumber)
                    {
                        item.Add(nameKey, type, date, category, description, value.ToString());                        
                    }           
                }
            }

            jsonAccounts = JsonConvert.SerializeObject(accounts);
            File.WriteAllText(_pathAccountsData, jsonAccounts);
            Console.WriteLine(jsonAccounts);
        }
    }
}
