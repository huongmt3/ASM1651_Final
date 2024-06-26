using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Code1651.ASM
{
    internal class Librarian : Person
    {
        //properties
        public decimal baseSalary;
        public decimal commission;

        //constructor
        public Librarian(string fullName, string phoneNumber, string emailAddress, decimal baseSalary, decimal commission) : base(fullName, phoneNumber, emailAddress)
        {
            SetFullName(fullName);
            SetPhoneNumber(phoneNumber);
            SetEmailAddress(emailAddress);
            SetBaseSalary(baseSalary);
            SetCommission(commission);

        }

        //default constructor
        public Librarian() : base("", "", "")
        {
            baseSalary = 0;
            commission = 0;
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

        //get-set for bаseSаlаry
        public decimal GetBаseSаlаry()
        {
            return baseSalary;
        }
        public void SetBaseSalary(decimal bаseSаlаry)
        {
            if ((bаseSаlаry < 100))
            {
                throw new ArgumentException("Bаse sаlаry must bigger thаn 100! Pleаse re - enter!");
            }
            this.baseSalary = bаseSаlаry;
        }

        //get-set for commission
        public decimal GetCommission()
        {
            return commission;
        }

        public void SetCommission(decimal commission)
        {
            if (commission < 10)
            {
                throw new ArgumentException("Commission must be >= 10");
            }
            this.commission = commission;
        }
        

        //InputInfo
        public override void InputInfo()
        {
            Console.WriteLine("Enter Librarian's Name: ");
            fullName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number: ");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email Address: ");
            emailAddress = Console.ReadLine();
            Console.WriteLine("Enter Librarian's Base Salary: ");
            while (!decimal.TryParse(Console.ReadLine(), out baseSalary) || baseSalary < 100)
            {
                Console.WriteLine("Base salary must bigger than 100. Please re-enter:");
            }

            Console.WriteLine("Enter Librarian's Commission: ");
            while (!decimal.TryParse(Console.ReadLine(), out commission) || commission < 10)
            {
                Console.WriteLine("Commission must greater than or equal to 10. Please re-enter:");
            }

        }

        //CalculateIncome
        public decimal CalculateIncome()
        {
            Console.WriteLine("======Calculate Income======");
            Console.WriteLine("Income = Base Salaray + Commission");
            Console.WriteLine($"Income = {baseSalary} + {commission}");
            return baseSalary + commission;
        }

        //ShowInfo
        public override void ShowInfo()
        {
            Console.WriteLine("\u001b[32m\n--------------------------");
            Console.WriteLine("Librarian Details");
            Console.WriteLine($"Full Name: {fullName}");
            Console.WriteLine($"Email Address: {emailAddress}");
            Console.WriteLine($"Librarian's Income: {CalculateIncome()}");
            Console.WriteLine("--------------------------\u001b[0m");
        }        
    }
}
