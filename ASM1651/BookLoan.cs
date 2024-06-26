using System;

namespace Code1651.ASM
{
    internal class BookLoan
    {
        //properties
        public int borrowingId;
        public Employee borrower = new Employee();
        public Book bookOnLoan = new Book();
        public DateTime issueDate;
        public DateTime dueDate;
        public DateTime returnDate;

        //constructor
        public BookLoan(int borrowingId, Employee borrower, Book bookOnLoan, DateTime issueDate, uint loanDurationDays)
        {
            SetBorrowingId(borrowingId);
            SetBorrower(borrower);
            SetBookOnLoan(bookOnLoan);
            SetIssueDate(issueDate);
            SetDueDate(issueDate.AddDays(loanDurationDays));
            //Initialise returnDate to a default value indicating it hasn't been set yet
            this.returnDate = default(DateTime);
        }

        //default constructor
        public BookLoan() { }

        //get-set for BorrowingId
        public int GetBorrowingId()
        {
            return borrowingId;
        }

        public void SetBorrowingId(int borrowingId)
        {
            this.borrowingId = borrowingId;
        }

        //get-set for Borrower
        public Employee GetBorrower()
        {
            return borrower;
        }

        public void SetBorrower(Employee borrower)
        {
            this.borrower = borrower;
        }

        //get-set for BookOnLoan
        public Book GetBookOnLoan()
        {
            return bookOnLoan;
        }

        public void SetBookOnLoan(Book bookOnLoan)
        {
            this.bookOnLoan = bookOnLoan;
        }

        //get-set for IssueDate
        public DateTime GetIssueDate()
        {
            return issueDate;
        }

        public void SetIssueDate(DateTime issueDate)
        {
            this.issueDate = issueDate;
        }

        //get-set for DueDate
        public DateTime GetDueDate()
        {
            return dueDate;
        }

        public void SetDueDate(DateTime dueDate)
        {
            this.dueDate = dueDate;
        }

        //get-set for ReturnDate
        public DateTime GetReturnDate()
        {
            return returnDate;
        }

        public void SetReturnDate(DateTime returnDate)
        {
            if (returnDate < issueDate)
            {
                throw new ArgumentException("Return date cannot be before the issue date!");
            }
            this.returnDate = returnDate;
        }

        //InputIssueDate
        public void InputIssueDate()
        {
            issueDate = DateTime.Now;
            Console.WriteLine("Enter the loan term for the book (in days).");
            uint duration = uint.Parse(Console.ReadLine());
            dueDate = issueDate.AddDays(duration);
            Console.WriteLine($"Issue date: {issueDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Due date: {dueDate.ToString("dd/MM/yyyy")}");
        }

        //InputReturnDate
        public void InputReturnDate()
        {
            Console.WriteLine("Enter return date:");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out returnDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                }
            }
            
            TimeSpan lateDays = returnDate - issueDate;
            if (lateDays.TotalDays > 14)
            {
                Console.WriteLine($"\u001b[31mThe book is returned late by {(lateDays.TotalDays - 14):0} days.");

            }
            else
            {
                Console.WriteLine("\u001b[32m\nThe book is returned on time.\u001b[0m");
            }
        }

        //LoanForm
        public void LoanForm()
        {
            Console.WriteLine("\u001b[32m\n--------------------------");
            Console.WriteLine("Book Loan Form");
            Console.WriteLine($"Borrowing ID: {borrowingId}");
            Console.WriteLine($"Issue Date: {issueDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Due Date: {dueDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Return Date: \u001b[31mNOT YET\u001b[32m");
            Console.WriteLine("--------------------------\u001b[0m");
        }

        //ShowTimeLine
        public void ShowTimeLine()
        {
            Console.WriteLine("\u001b[32m\n--------------------------");
            Console.WriteLine("Book Loan Timeline");
            Console.WriteLine($"Borrowing ID: {borrowingId}");
            Console.WriteLine($"Issue Date: {issueDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Due Date: {dueDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Return Date: {returnDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine("--------------------------\u001b[0m");
        }
    }
}
