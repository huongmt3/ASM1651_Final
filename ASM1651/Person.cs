using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code1651.ASM
{
    abstract class Person
    {
        //properties
        public string fullName;
        public string phoneNumber;
        public string emailAddress;

        //constructor
        public Person(string fullName, string phoneNumber, string emailAddress)
        {
            SetFullName(fullName);
            SetPhoneNumber(phoneNumber);
            SetEmailAddress(emailAddress);
        }

        //get-set for fullName
        public string GetFullName()
        {
            return fullName;
        }

        public void SetFullName(string fullName)
        {
            this.fullName = fullName;
        }

        //get-set for phoneNumber
        public string GetPhoneNumber()
        {
            return phoneNumber;
        }
        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        //get-set for emailAddress
        public string GetEmailAddress()
        {
            return emailAddress;
        }
        public void SetEmailAddress(string emailAddress)
        {
            this.emailAddress = emailAddress;
        }

        //InputInfo
        public abstract void InputInfo();

        //ShowInfo
        public abstract void ShowInfo();
    }
}
