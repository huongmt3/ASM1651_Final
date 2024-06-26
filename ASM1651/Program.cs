using Code1651.ASM;
using System;

namespace Code1651.ASM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library1 = Library.Instance;

            bool exit = false;
            while (!exit)
            {
                library1.Greeting();
                library1.ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library1.ShowBookList();
                        break;
                    case "2":
                        library1.DisplayAvailableBooks();
                        break;
                    case "3":
                        library1.ShowBookLoanList();
                        break;
                    case "4":
                        library1.AddBook();
                        break;
                    case "5":
                        library1.SearchBookByTitle();
                        break;
                    case "6":
                        library1.UpdateOrDeleteBook();
                        break;
                    case "7":
                        library1.LendBook();
                        break;
                    case "8":
                        library1.ReceiveBook();
                        break;
                    case "9":
                        library1.UpdateBorrower();
                        break;
                    case "10":
                        library1.FindMostFrequentBorrower();
                        break;
                    case "11":
                        library1.AddNewBorrower();
                        break;
                    case "12":
                        library1.ViewLibrarianInfo();
                        break;
                    case "13":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}
