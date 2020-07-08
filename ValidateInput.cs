/* 
 * 
 * 2: only alphabets, start with capital, maximum length of 30. Min length? other capitals?
 *  : make our decision on single letter names and mixed case names.
 *  : include it commented in the code.
 * 3: 
 * 4: 
 * 5: 
 * 
 * 
 */


using System;
using System.Text.RegularExpressions;

namespace DB4_Validating_Input
{
    class ValidateInput
    {
        private Regex emailValidator;
        private Regex nameValidator;
        private Regex dateValidator;
        private Regex phoneNumberValidator;

        public ValidateInput()
        {
            emailValidator = new Regex(@"^[A-Za-z0-9]{5,30}@[A-Za-z0-9]{5,10}\.[A-Za-z0-9]{2,3}$");
            nameValidator = new Regex(@"^[A-Z][A-Za-z]{1,29}$");
            dateValidator = new Regex(@"(^[1-9]|(0[1-9]|1[0-9]|2[0-9]|30|31))[\/\-]([1-9]|(0[1-9]|10|11|12))[\/\-]([12][0-9][0-9][0-9]|[012][1-9]|[12][0-9])$");
            phoneNumberValidator = new Regex(@"^\(?\d\d\d(\)?[\.\-\s]|\))\d\d\d[\.\-]\d\d\d\d$");
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
                moreEntries = RunAgain();
            }
        }

        private string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private bool RunAgain()
        {
            string again = GetInput("\nContinue? (Y/Yes, anything else quits: ");
            Console.WriteLine("");
            if(again.ToUpper() == "Y" || again.ToUpper() == "YES")
            {
                Console.Clear();
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
        private void VerifyName(string input)
        {
            if (nameValidator.IsMatch(input))
            {
                Console.WriteLine($"{input} is a valid name!");
            }
            else
            {
                Console.WriteLine($"Sorry, {input} is NOT a valid name!");
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
        private void VerifyEmail(string input)
        {
            if (emailValidator.IsMatch(input))
            {
                Console.WriteLine($"{input} is a valid email!");
            }
            else
            {
                Console.WriteLine($"Sorry, {input} is NOT a valid email!");
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
        private void VerifyPhoneNumber(string input)
        {
            if (phoneNumberValidator.IsMatch(input))
            {
                Console.WriteLine($"{input} is a valid phone number!");
            }
            else
            {
                Console.WriteLine($"Sorry, {input} is NOT a valid phone number!");
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
         * format is
         * day/month/year
         * 
         * Valid Entries:
         * 1/1/1000
         * 31/12/2999
         * 01/01/01
         * 31/12/29
         * 
         */
        private void VerifyDate(string input)
        {
            if (dateValidator.IsMatch(input))
            {
                Console.WriteLine($"{input} is a valid date!");
            }
            else
            {
                Console.WriteLine($"Sorry, {input} is NOT a valid date!");
            }
        }
    }
}
