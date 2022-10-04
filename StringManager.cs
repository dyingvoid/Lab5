namespace Lab5
{
    public static class StringManager
    {
        /// <summary>
        /// Finds sum of digits in input. If input  is negative,
        /// the first digit is considered to be negative.
        /// </summary>
        /// <param name="input">string number</param>
        /// <returns>Sum of digits</returns>
        public static int FindSumOfDigitsInNumber(string input)
        {
            char minNumber = '0';
            int answer;
            foreach (var ch in input)
            {
                minNumber += ch;
            }
            answer =  minNumber - '0' - (48 * input.Length);
            if (IsNegative(input))
                answer = minNumber - '0' - '-' - (input[1] * 2) + 48 - (48 * (input.Length - 2));
            return answer;
        }

        /// <summary>
        /// Checks if set formed from input is subset of checking set,
        /// to be precious if string contains nums
        /// or '-' in the right place(cant be [1] or further)
        /// </summary>
        /// <param name="input">string number</param>
        /// <returns>true for right or empty input, false otherwise</returns>
        public static bool CheckForWrongChars(string input)
        {
            bool answer;
            //using two hashsets is claimed to be O(n)
            var inputSet = new HashSet<char>(input);
            var testingSet = new HashSet<char>(
                new[] { '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }
                );
            answer = inputSet.IsProperSubsetOf(testingSet) &&
                     input.Substring(1, input.Length - 1).IndexOf('-') == -1;
            if (answer && input.Length == 1)
                answer = input[0] != '-';
            return answer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns>string without '-' in [0] place</returns>
        public static string StringAbs(string number)
        {
            string absedString = "";
            if (number.Length > 0)
            {
                absedString = number[0] == '-' ? number.Substring(1, number.Length - 1) : number;
            }
            return absedString;
        }

        public static bool IsNegative(string number)
        {
            bool answer = number[0] == '-';
            return answer;
        }

        /// <summary>
        /// Checks input to be less than value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns>true if input is bigger than value, false otherwise</returns>
        public static bool CheckForIntOverflow(string input, string value)
        {
            bool answer = false;
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
