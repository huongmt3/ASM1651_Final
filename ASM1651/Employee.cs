using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Code1651.ASM
{
    internal class Employee : Person
    {
        //properties
        public string employeeId;
        public List<BookLoan> BookLoans = new List<BookLoan>();

        //constructor
        public Employee(string fullName, string phoneNumber, string emailAddress, string employeeId) : base(fullName, phoneNumber, emailAddress)
        {
            SetFullName(fullName);
            SetPhoneNumber(phoneNumber);
            SetEmailAddress(emailAddress);
            SetEmployeeId(employeeId);
        }

        //default constructor
        public Employee() : base("", "", "")
        {
            employeeId = "";
        }

        //override set methods with validation
        public new void SetFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be null or empty!");
            }
            if (Regex.IsMatch(fullName, @"[\d\W]"))
            {
                throw new ArgumentException("Full name cannot contain numbers or special characters!");
            }
            base.SetFullName(fullName);
        }

        public new void SetPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length > 10)
            {
                throw new ArgumentException("Phone number cannot be longer than 10 characters!");
            }
            if (!Regex.IsMatch(phoneNumber, @"^[\d\s\.\-]+$"))
            {
                throw new ArgumentException("Phone number can only contain digits, spaces, dots, and dashes!");
            }
            base.SetPhoneNumber(phoneNumber);
        }

        public new void SetEmailAddress(string emailAddress)
        {
            if (!emailAddress.EndsWith("@fe.edu.vn"))
            {
                throw new ArgumentException("Email address must end with '@fe.edu.vn'!");
            }
            base.SetEmailAddress(emailAddress);
        }

        //get-set for Employee ID
        public string GetEmployeeId()
        {
            return employeeId;
        }

        public void SetEmployeeId(string employeeId)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
            {
                throw new ArgumentException("Employee's ID cannot be null or empty!");
            }
        }

        //InputInfo
        public override void InputInfo()
        {
            Console.WriteLine("Enter Name: ");
            fullName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email Address: ");
            emailAddress = Console.ReadLine();
            Console.WriteLine("Enter Employee's ID: ");
            employeeId = Console.ReadLine();
        }

        //ShowInfo
        public override void ShowInfo()
        {
            Console.WriteLine("\u001b[32m\n--------------------------");
            Console.WriteLine("Employee Details");
            Console.WriteLine($"Full Name: {fullName}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Email Address: {emailAddress}");
            Console.WriteLine($"Employee ID: {employeeId}");
            Console.WriteLine("--------------------------\u001b[0m");
        }
    }
}
