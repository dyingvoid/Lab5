using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public static class StringManager
    {
        public static int FindSumOfDigitsInNumber(string input)
        {
            char minNumber = '0';
            foreach (var ch in input)
            {
                minNumber += ch;
            }
            return minNumber - '0' - (48 * input.Length);
        }

        //Check if set formed from input is subset of checking set
        //to be precious if string contains nums
        //or '-' in the right place([0] or no occurence)
        //returns true for empty string, check docs to know why
        public static bool CheckForWrongChars(string input)
        {
            bool answer = false;
            //using two hashsets is claimed to be O(n)
            var inputSet = new HashSet<char>(input);
            var testingSet = new HashSet<char>(
                new char[] { '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }
                );
            answer = inputSet.IsProperSubsetOf(testingSet) &&
                     input.IndexOf('-') <= 0;
            return answer;
        }

        public static string StringAbs(string number)
        {
            string absedString = "";
            if (number.Length > 0)
            {
                if (number[0] == '-')
                    absedString = number.Substring(1, number.Length - 1);
                else
                    absedString = number;
            }
            return absedString;
        }

        public static bool IsNegative(string number)
        {
            bool answer = false;
            if (number[0] == '-')
            {
                answer = true;
            }
            return answer;
        }

        public static bool CheckForIntOverflow(string input, string value)
        {
            bool answer = false;
            //input must be less or equal than value
            if (input.Length > value.Length)
            {
                answer = true;
            }
            else if (input.Length == value.Length)
            {
                foreach (var (inputChar, maxIntChar) in input.Zip(value))
                {
                    if (inputChar > maxIntChar)
                        answer = true;
                }
            }
            return answer;
        }
    }
}
