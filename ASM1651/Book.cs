using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Code1651.ASM
{
    internal class Book
    {
        public int bookId;
        public string title;
        public string author;
        public string category;
        public int quantity;
        public bool availableStt;

        //constructor
        public Book(int bookId, string title, string author, string category,
            int quantity)
        {
            this.bookId = bookId;
            //SetBookId(bookId);
            SetBookTitle(title);
            SetBookAuthor(author);
            SetBookCategory(category);
            SetBookQuantity(quantity);
            AvailableStt = true;
        }

        //default constructor
        public Book() { }

        //get-set for Bpok ID
        public int GetBookId()
        {
            return bookId;
        }

        public void SetBookId(int bookId)
        {
            if (bookId > 600)
            {
                throw new ArgumentException("Library Overload");
            }
        }

        //get-set for Book Title
        public string GetBookTitle()
        {
            return title;
        }

        public void SetBookTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                this.title = title;
            }
            else
            {
                throw new ArgumentException("Title cannot be null or empty.");
            }
        }


        //Validate Author (only letters and spaces)
        private bool IsValidAuthor(string author)
        {
            return Regex.IsMatch(author, @"^[a-zA-Z\s]+$");
        }
        //get-set for Book Author
        public string GetBookAuthor()
        {
            return author;
        }
        public void SetBookAuthor(string author)
        {
            if (!string.IsNullOrEmpty(author))
            {
                this.author = author;
            }
            else
            {
                throw new ArgumentException("Author cannot be null or empty.");
            }
            if (IsValidAuthor(author))
            {
                this.author = author;
            }
            else
            {
                throw new ArgumentException("Author cannot contain numbers or special characters except space.");
            }
        }


        //Validate Category (only letters and spaces)
        private bool IsValidCategory(string category)
        {
            return Regex.IsMatch(category, @"^[a-zA-Z\s]+$");
        }
        //get-set for Book Category
        public string GetBookCategory()
        {
            return category;
        }
        public void SetBookCategory(string category)
        {
            if (!string.IsNullOrEmpty(category))
            {
                this.category = category;
            }
            else
            {
                throw new ArgumentException("Category cannot be null or empty.");
            }
            if (IsValidCategory(category))
            {
                this.category = category;
            }
            else
            {
                throw new ArgumentException("Category cannot contain numbers or special characters except space.");
            }
        }

        //get-set for Quantity
        public int GetBookQuantity()
        {
            return quantity;
        }
        public void SetBookQuantity(int quantity)
        {
            if (quantity > 0)
            {
                this.quantity = quantity;
            }
            else
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
        }

        //get-set for availableStt
        public bool AvailableStt
        {
            get { return availableStt; }
            set { availableStt = value; }
        }

        //Set available status of the book
        public void SetBookAvailableStt(bool available)
        {
            availableStt = available;
        }

        //InputInfo
        public void InputInfo()
        {
            Console.WriteLine("Enter Book Information: ");
            Console.WriteLine("Book Title: ");
            title = Console.ReadLine();
            Console.WriteLine("Author Name: ");
            author = Console.ReadLine();
            Console.WriteLine("Category: ");
            category = Console.ReadLine();
            Console.WriteLine("Quantity: ");
            quantity = int.Parse(Console.ReadLine());
        }

        // Display book details
        public void DisplayBookInfo()
        {
            Console.WriteLine("\u001b[32m\n--------------------------");
            Console.WriteLine("Book Details");
            Console.WriteLine($"Book ID: {bookId}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Category: {category}");
            Console.WriteLine($"Quantity: {quantity}");
            Console.WriteLine($"Availability: {(AvailableStt ? "Available" : "Not Available")}");
            Console.WriteLine("--------------------------\u001b[0m");
        }

        //ShowBookOnLoan
        public void ShowBookOnLoan()
        {
            Console.WriteLine("\u001b[32m\n--------------------------");
            Console.WriteLine("Book On Loan: ");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Category: {category}");
            Console.WriteLine("--------------------------\u001b[0m");
        }
    }
}
