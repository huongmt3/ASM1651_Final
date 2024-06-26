using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Code1651.ASM
{
    internal class Library
    {
        //properties
        public string libraryName { get; set; }
        public List<Book> Books = new List<Book>();
        public List<Employee> Borrowers = new List<Employee>();
        public List<BookLoan> BookLoans = new List<BookLoan>();

        //constructor
        public Library(string libraryName) => this.libraryName = libraryName;

        //singleton
        private static Library instance = null;
        private static readonly object padlock = new object();

        public static Library Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        Console.WriteLine("Enter Library Name: ");
                        string libraryName = Console.ReadLine();
                        instance = new Library(libraryName);
                    }
                    return instance;
                }
            }
        }

        //Greeting
        public void Greeting()
        {
            Console.WriteLine("\u001b[33m\n============================================");
            Console.WriteLine($"WELCOME TO {libraryName.ToUpper()} LIBRARY!");
            Console.WriteLine("============================================\u001b[0m");
        }

        //ShowMenu
        public void ShowMenu()
        {
            Console.WriteLine("\u001b[33m\n--------------MENU--------------");
            Console.WriteLine("1. Display all book");
            Console.WriteLine("2. Display available books");
            Console.WriteLine("3. Display list of book on loan");
            Console.WriteLine("4. Add a new book");
            Console.WriteLine("5. Search book by title");
            Console.WriteLine("6. Update/Delete a book by book ID");
            Console.WriteLine("7. Lend a book for an employee");
            Console.WriteLine("8. Receive a borrowed book from an employee");
            Console.WriteLine("9. Update employee's information");
            Console.WriteLine("10. Display top 1 borrower");
            Console.WriteLine("11. Exit\u001b[0m");
        }

        //AddBook
        public void AddBook()
        {
            try
            {

                Book newBook = new Book();
                if (Books.Any())
                    newBook.bookId = Books.Last().bookId + 1;
                else newBook.bookId = 1;
                newBook.InputInfo();
                Books.Add(newBook);
                newBook.SetBookAvailableStt(true);
                Console.WriteLine("Added successfully!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a number. \n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }

        //ShowBookList
        public void ShowBookList()
        {
            if (Books.Any())
            {
                Console.WriteLine("Book List: ");
                foreach (Book book in Books)
                    book.DisplayBookInfo();
            }
            else Console.WriteLine("Currently there are no books in the library.");
        }

        public void ShowBookList(List<Book> books)
        {
            foreach (Book book in books)
                book.DisplayBookInfo();
        }

        //ShowBookLoanList
        public void ShowBookLoanList()
        {
            if (!BookLoans.Any())
                Console.WriteLine("No one has ever borrowed a book here!");
            else
            {
                Console.WriteLine("Information about books borrowing");
                foreach (BookLoan bl in BookLoans)
                {
                    if (bl.returnDate == DateTime.MinValue)
                        bl.LoanForm();
                    bl.bookOnLoan.ShowBookOnLoan();
                    bl.ShowTimeLine();
                    Console.WriteLine("=============================");
                    Console.WriteLine();
                }
            }
        }

        //DisplayAvailableBooks
        public void DisplayAvailableBooks()
        {
            if (!Books.Any())
                Console.WriteLine("Currently there are no books in the library.");
            else
            {
                Console.WriteLine("Available Books:\n");
                foreach (var book in Books.Where(b => b.AvailableStt))
                {
                    Console.WriteLine($"{book.title} by {book.author}");
                    Console.WriteLine($"Quantity: {book.quantity}");
                    Console.WriteLine("=========================");
                }
            }
        }

        //SearchBookByTitle
        public void SearchBookByTitle()
        {
            Console.WriteLine("Please enter title of the book you want to see the information: ");
            string searchKeyWord = Console.ReadLine();

            bool found = false;
            foreach (Book book in Books)
            {
                if (book.title.ToLower().Contains(searchKeyWord.ToLower()))
                {
                    book.DisplayBookInfo();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Library does not have any book with title containing '\u001b[32m\n{searchKeyWord}\u001b[0m'.");
            }
        }

        //=======Employee Functions========
        //Update Employee Info
        public void UpdateEmployee()
        {
            Console.WriteLine("List of Employees:");
            foreach (var employee in Borrowers)
            {
                employee.ShowInfo();
            }

            Console.WriteLine("Please enter employee's ID: ");
            string employeeId = Console.ReadLine();
            Employee employeeInList = Borrowers.FirstOrDefault(b => b.employeeId.Equals(employeeId));
            if (employeeInList == null)
            {
                Console.WriteLine("This employee does not exist! Do you want to add new employee? (Y/N)");
                string choice = Console.ReadLine();
                while (!choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase)
                    && !choice.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Invalid choice! Please re-enter your choice: ");
                    choice = Console.ReadLine();
                }
                if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    employeeInList = AddNewEmployee(employeeId);
                else 
                    Console.WriteLine("Operation canceled.");
                    return;
            }
            UpdateEmployee(employeeInList);            
        }

        private Employee AddNewEmployee(string employeeId)
        {
            try
            {
                Employee newEmployee = new Employee();
                newEmployee.employeeId = employeeId;
                newEmployee.InputInfo();
                Borrowers.Add(newEmployee);
                Console.WriteLine("New employee added successfully!");
                return newEmployee;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding new employee: {ex.Message}");
                return null;
            }
        }

        private static void UpdateEmployee(Employee employeeToUpdate)
        {
            employeeToUpdate.InputInfo();
            Console.WriteLine("Employee Updated Successfully!");
        }

        //======Book Functions=======
        //FindBookById
        private Book FindBookById()
        {
            Book bookInList = null;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please Enter Book's ID: ");
                    int bookId = int.Parse(Console.ReadLine());
                    bookInList = Books.FirstOrDefault(b => b.bookId == bookId);

                    if (bookInList == null)
                    {
                        Console.WriteLine("The library does not has this book! Please enter another book ID:");
                    }
                    else if (bookInList.quantity == 0)
                    {
                        Console.WriteLine("This book is out of stock! Please enter another book ID:");
                    }
                    else
                    {
                        return bookInList;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid book ID:");
                }
            }
        }

        //Update & Delete
        public void UpdateOrDeleteBook()
        {
            
            Book bookInList = FindBookById();
            bookInList.DisplayBookInfo();

            Console.WriteLine("Type 'U' for Update, 'D' for Delete. Please enter your choice: ");
            string choice = Console.ReadLine();
            while (!choice.Equals("U", StringComparison.InvariantCultureIgnoreCase)
                && !choice.Equals("D", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Invalid choice! Please re-enter your choice: ");
                choice = Console.ReadLine();
            }
            if (choice.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                UpdateBook(bookInList);
            else DeleteBook(bookInList);
        }

        private static void UpdateBook(Book bookToUpdate)
        {
            bookToUpdate.InputInfo();
            Console.WriteLine("Book Updated Successfully!");   
        }

        private static void DeleteBook(Book bookToDelete)
        {
            Library.Instance.Books.Remove(bookToDelete);
            Console.WriteLine("Book Deleted Successfully!");
        }

        private static int lastBorrowingId = 0;

        //LendBook()
        public void LendBook()
        {
            if (!Books.Any())
            {
                Console.WriteLine("Currently there are no books to be lent to employees");
                return;
            }

            Console.WriteLine("Enter employee's information: ");
            Console.WriteLine("Employee's ID: ");
            string employeeId = Console.ReadLine();
            Employee employeeInList = Borrowers.FirstOrDefault(b => b.employeeId.Equals(employeeId));

            if (employeeInList != null && employeeInList.BookLoans.Any(b => b.returnDate == DateTime.MinValue))
            {
                Console.WriteLine("This employee has an unreturned book. Please return the book before borrowing another one.");
                return;
            }

            if (employeeInList == null)
            {
                Console.WriteLine("This employee does not exist in the system. Do you want to add this employee? (Y/N)");
                string choice = Console.ReadLine();
                while (!choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase)
                && !choice.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Invalid choice! Please re-enter your choice: ");
                    choice = Console.ReadLine();
                }
                if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    employeeInList = AddNewEmployee(employeeId);
                else
                {
                    Console.WriteLine("Operation canceled.");
                    return;
                }
            }

            Console.WriteLine("Enter the ID of the book to borrow: ");
            string inputBookId = Console.ReadLine();

            if (!int.TryParse(inputBookId, out int bookId))
            {
                Console.WriteLine("Invalid input. Please enter a valid book ID (numeric).");
                return;
            }

            Book bookToBorrow = Books.FirstOrDefault(b => b.bookId == bookId);

            if (bookToBorrow == null)
            {
                Console.WriteLine("Book not found in the system.");
                return;
            }

            if (bookToBorrow.quantity == 0)
            {
                Console.WriteLine("This book is currently not available for borrowing.");
                return;
            }

            bookToBorrow.DisplayBookInfo();

            int borrowingId = ++lastBorrowingId;

            BookLoan newLoan = new BookLoan(borrowingId, employeeInList, bookToBorrow, DateTime.Now, 0);

            newLoan.InputIssueDate();
            bookToBorrow.quantity--;
            if (bookToBorrow.quantity == 0)
            {
                bookToBorrow.SetBookAvailableStt(false);
            }

            employeeInList.BookLoans.Add(newLoan);
            BookLoans.Add(newLoan);

            Console.WriteLine();
            Console.WriteLine("Book successfully lent.");
            newLoan.LoanForm();
        }

        //ReceiveBook
        public void ReceiveBook()
        {
            Console.WriteLine("Please enter the employee's ID who is returning a book: ");
            string employeeId = Console.ReadLine();
            Employee employeeInList = Borrowers.FirstOrDefault(b => b.employeeId.Equals(employeeId));

            if (employeeInList == null)
            {
                Console.WriteLine("This employee does not exist in the system.");
                return;
            }

            var loanedBook = employeeInList.BookLoans.FirstOrDefault(b => b.returnDate == DateTime.MinValue);
            if (loanedBook == null)
            {
                Console.WriteLine("This employee has no books to return.");
                return;
            }

            employeeInList.ShowInfo();
            loanedBook.LoanForm();
            loanedBook.bookOnLoan.ShowBookOnLoan();
            loanedBook.InputReturnDate();

            loanedBook.bookOnLoan.quantity++;
            if (loanedBook.bookOnLoan.quantity > 0)
            {
                loanedBook.bookOnLoan.SetBookAvailableStt(true);
            }

            Console.WriteLine("Book return successfully!");
        }


        //FindMostFrequentBorrower
        public void FindMostFrequentBorrower()
        {
            if (!Borrowers.Any())
                Console.WriteLine("No one has ever become library's member");
            else
            {
                int maxBookLoan = 0;
                foreach (Employee e in Borrowers)
                {
                    if (e.BookLoans.Count > maxBookLoan)
                        maxBookLoan = e.BookLoans.Count;
                }

                if (maxBookLoan == 0)
                {
                    Console.WriteLine("No one has ever borrowed a book here");
                    return;
                }

                Console.WriteLine("The employee who borrows books the most often is: ");
                foreach (Employee e in Borrowers)
                {
                    if (e.BookLoans.Count == maxBookLoan)
                        e.ShowInfo();
                }
            }
        }
    }
}
