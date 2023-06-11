using System;


namespace GerenciamentoDespesas
{
    public class Program
    {
        public static void Main(string[] args)
        {

            int option;

            do
            {
                Print.ShowMainMenu();
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        Account.AccountManagementMenu();
                        break;
                    case 2:
                        Transactions.IncludeTransaction();
                        break;
                    case 3:
                        Panel.DetailsAccount();
                        break;
                    case 4:
                        Print.Exit();
                        break;
                    default:
                        Print.InvalidInputWarning();
                        break;
                }
            }
            while (option != 4);

        }
    }
}
    
