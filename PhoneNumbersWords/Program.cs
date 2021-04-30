using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumbersWords
{
    class Program
    {
        // this is const 
        public static readonly string[] pairs = new string[] { "0", "1", "abc", "def", "ghi", "klm", "nop", "qrs", "tuv", "wxyz" };

        static void Main(string[] args)
        {
            //string phoneNumber = "123";
            string phoneNumber = "1790";

            Print(PhoneNumberToString(phoneNumber));

            Console.WriteLine();

            Print(PhoneNumberToStringWRecursion(phoneNumber));

        }

        static void Print(List<string> stringNumbers) {
            foreach (var stringNumber in stringNumbers)
            {
                Console.Write(stringNumber + "   ");
            }

            Console.WriteLine();
        }

        static private List<string> PhoneNumberToString (string phoneNumber) 
        {
            var stringNumbers = new List<string>();

            foreach (var c in phoneNumber)
            {
                string letters = pairs[int.Parse(c.ToString())];
                var newStringNumbers = new List<string>();

                foreach (var l in letters)
                {
                    if (stringNumbers.Count == 0)
                    {
                        newStringNumbers.Add(l.ToString());
                    }
                    else
                    {
                        foreach (string stringNumber in stringNumbers)
                        {
                            newStringNumbers.Add(stringNumber + l.ToString());
                        }
                    }
                }

                stringNumbers = newStringNumbers;
            }

            return stringNumbers;
        }

        static private List<string> PhoneNumberToStringWRecursion(string phoneNumber, List<string> stringNumbers = null)
        {
            if (stringNumbers == null)
                stringNumbers = new List<string>();

            if (phoneNumber.Length == 0)
                return stringNumbers;

            string c = phoneNumber[0].ToString();
            string letters = pairs[int.Parse(c.ToString())];
            var newStringNumbers = new List<string>();

            foreach (var l in letters)
            {
                if (stringNumbers.Count == 0)
                {
                    newStringNumbers.Add(l.ToString());
                }
                else
                {
                    foreach (string stringNumber in stringNumbers)
                    {
                        newStringNumbers.Add(stringNumber + l.ToString());
                    }
                }
            }

            string newPhoneNumber = phoneNumber.Substring(1, phoneNumber.Length - 1);
            return PhoneNumberToStringWRecursion(newPhoneNumber, newStringNumbers);
        }

    }
}
