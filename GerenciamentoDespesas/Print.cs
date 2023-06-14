using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDespesas
{
    public class Print
    {

        public static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t-------------------------------------------------------");
            Console.WriteLine("\t   Welcome to your Personal Expense Management App!");
            Console.WriteLine("\t-------------------------------------------------------");
            Console.ResetColor();
        }
        public static void ShowMainMenu()
        {
            Welcome();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\t -------- Main Menu --------\n");
            Console.ResetColor();

            Console.WriteLine("\t1. Account Management");
            Console.WriteLine("\t2. Transaction Management");
            Console.WriteLine("\t3. General Panel");
            Console.WriteLine("\t4. Leave App\n");

            Console.Write("\tEnter your option: ");
        }

        public static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nClosing App... Thanks for spending this time with us!\n");
            Console.WriteLine("Come back whenever you need!");
            Console.ResetColor();
        }

        public static void InvalidInputWarning()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n Invalid Input. Please, try again.");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowContinueMessage()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPlase, press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

    }
}
