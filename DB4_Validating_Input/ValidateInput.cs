/* 
 * 
 * Created by Chuck Allen as a lab submission.
 * Shows the use of Regular Expressions in verifying
 * emails, names, dates, phone numbers, and HTML segments.
 * 
 * 
 */


using System;
using System.Text.RegularExpressions;

namespace DB4_Validating_Input
{
    public class ValidateInput
    {
        private Regex emailValidator;
        private Regex nameValidator;
        private Regex dateValidator;
        private Regex phoneNumberValidator;
        private Regex htmlValidator;

        public ValidateInput()
        {
            emailValidator = new Regex(@"^[A-Za-z0-9]{5,30}@[A-Za-z0-9]{5,10}\.[A-Za-z0-9]{2,3}$");
            nameValidator = new Regex(@"^[A-Z][A-Za-z]{1,29}$");
            dateValidator = new Regex(@"(^[1-9]|(0[1-9]|1[0-9]|2[0-9]|30|31))[\/\-]([1-9]|(0[1-9]|10|11|12))[\/\-]([12][0-9][0-9][0-9]|[012][1-9]|[12][0-9])$");
            phoneNumberValidator = new Regex(@"^\(?\d\d\d(\)?[\.\-\s]|\))\d\d\d[\.\-]\d\d\d\d$");
            htmlValidator = new Regex(@"^<([A-Za-z0-9]+)>.*<\/\1>$");
        }

        public void Start()
        {
            bool moreEntries = true;

            while (moreEntries)
            {
                VerifyName(GetInput("Please enter a valid name: "));
                VerifyEmail(GetInput("\nPlease enter a valid email: "));
                VerifyPhoneNumber(GetInput("\nPlease enter a valid phone number: "));
                VerifyDate(GetInput("\nPlease enter a valid date: "));
                VerifyHTML(GetInput("\nPlease enter a valid HTML segment: "));
                moreEntries = RunAgain(GetInput("\nContinue? (Y/Yes, anything else quits: "));
                Console.Clear();
            }
        }

        private string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public bool RunAgain(string again)
        {
            Console.WriteLine("");
            if(again.ToUpper() == "Y" || again.ToUpper() == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* 
         * Name Rules:
         * The name must start with a capital letter. Other letters may be capital
         * It must be between 2 and 30 characters long.
         * Pnly letters are allowed.
         * 
         */
        public bool VerifyName(string input)
        {
            if (nameValidator.IsMatch(input))
            {
                Console.WriteLine($"{input} is a valid name!");
                return true;
            }
            else
            {
                Console.WriteLine($"Sorry, {input} is NOT a valid name!");
                return false;
            }
        }

        /* 
         * Email Rules:
         * 5 to 30 Alpha Numeric characters followed by @ then
         * 5 to 10 Alpha Numeric characters followed by . then
         * 2 to  3 Alpha Numeric characters.
         * 
         * Special Characters are not allowed, numbers are allowed even after the .
         * 
         */
        public bool VerifyEmail(string input)
        {
            if (emailValidator.IsMatch(input))
            {
                Console.WriteLine($"{input} is a valid email!");
                return true;
            }
            else
            {
                Console.WriteLine($"Sorry, {input} is NOT a valid email!");
                return false;
            }
        }

        /* 
         * Phone Number Rules:
         * Must have a 3 digit area code follow by 3 digits followed by 4 digits.
         * Separators must be used between the sections with . and - being interchangable.
         * If using () around the area code the first separator is not required.
         * A space is acceptable as the first separator.
         * 
         * Valid Entries:
         * 333-333.3333
         * (333)333.3333
         * (333).333.3333
         * (333) 333.3333
         * (333.333.3333
         * (333 333.3333
         * 333).333.3333
         * 333 333.3333
         * 
         */
        public bool VerifyPhoneNumber(string input)
        {
            if (phoneNumberValidator.IsMatch(input))
            {
                Console.WriteLine($"{input} is a valid phone number!");
                return true;
            }
            else
            {
                Console.WriteLine($"Sorry, {input} is NOT a valid phone number!");
                return false;
            }
        }

        /* 
         * Date Rules:
         * 
         * Accepts a 1 or 2 digit day and/or month.
         * days are between 1-31
         * months are from 1-12
         * years are from 1000-2999 if using 4 digit
         * or 01-29 if using 2 digit.
         * format is:
         * day/month/year
         * - can be substituted for the /
         * 
         * Valid Entries:
         * 1/1/1000
         * 31/12/2999
         * 01/01/01
         * 31/12/29
         * 01-01-01
         * 
         */
        public bool VerifyDate(string input)
        {
            if (dateValidator.IsMatch(input))
            {
                Console.WriteLine($"{input} is a valid date!");
                return true;
            }
            else
            {
                Console.WriteLine($"Sorry, {input} is NOT a valid date!");
                return false;
            }
        }

        public bool VerifyHTML(string input)
        {
            if (htmlValidator.IsMatch(input))
            {
                Console.WriteLine($"{input} is a valid segment of HTML!");
                return true;
            }
            else
            {
                Console.WriteLine($"Sorry, {input} is NOT a valid segment of HTML!");
                return false;
            }
        }
    }
}
