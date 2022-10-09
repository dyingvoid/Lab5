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
        /// and '-' or '.' in the right place(cant be [1] or further)
        /// </summary>
        /// <param name="input">number in string form</param>
        /// <param name="additionalSymbols">List of checking chars</param>
        /// <returns>true for right or empty input, false otherwise</returns>
        public static bool CheckForWrongChars(string input, List<char> additionalSymbols)
        {
            bool answer;
            additionalSymbols ??= new List<char>() { };
            //using two hashsets is claimed to be O(n)
            var inputSet = new HashSet<char>(input);
            var testingSet = new HashSet<char>(additionalSymbols);
            
            answer = inputSet.IsProperSubsetOf(testingSet) &&
                     input.Substring(1, input.Length - 1).IndexOf('-') == -1;
            if (answer && input.Length == 1)
            {
                answer = input[0] != '-';
            }

            return answer;
        }

        /// <summary>
        /// Uses StringManager.CheckForWrongChars()
        /// with possible integer chars in additionalSymbols list
        /// </summary>
        /// <param name="input">number in string form</param>
        /// <returns>true if integer, false otherwise</returns>
        public static bool IsInt(string input)
        {
            var checkList = new List<char> {
                '0', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', '-'
            };
            bool answer = CheckForWrongChars(input, checkList);
            return answer;
        }
        
        /// <summary>
        /// Uses StringManager.CheckForWrongChars()
        /// with possible float chars in additionalSymbols list
        /// </summary>
        /// <param name="input">number in string form</param>
        /// <returns>true if float, false otherwise</returns>
        public static bool IsFloat(string input)
        {
            var checkList = new List<char>(){
                '0', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', '-', '.'
            };
            int pointIdx = input.IndexOf('.');
            
            bool answer = CheckForWrongChars(input, checkList) &&
                          input.Count(x=> x =='.') == 1 &&
                          pointIdx != 0 &&
                          input.Length - pointIdx - 1 > 0 &&
                          IsInt(input[pointIdx - 1].ToString());
            return answer;
        }

        /// <summary>
        /// </summary>
        /// <param name="number"></param>
        /// <returns>string without '-' at [0] index</returns>
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
        /// Checks input to be bigger than value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns>true if input is bigger than value, false otherwise</returns>
        public static bool IsBigger(string input, string value)
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

        public static string RoundAndCut(string number, int midPointCut)
        {
            number = Cut(Round(number, midPointCut));
            return number;
        }
        
        public static string Cut(string number)
        {
            string cutNumber;
            int pointIndex = number.IndexOf('.');
            cutNumber = number.Substring(pointIndex + 1, number.Length - pointIndex - 1);

            int startingDigitIndex = 0;
            foreach (var digit in cutNumber)
            {
                if (digit != 0)
                    break;
                startingDigitIndex += 1;
            }
            return cutNumber.Substring(startingDigitIndex + 1, cutNumber.Length - startingDigitIndex - 1);
        }
        
        /// <summary>
        /// Round a string number at midPoint to the nearest value
        /// </summary>
        /// <param name="number">string number</param>
        /// <param name="midPointRounding">point of rounding</param>
        /// <returns>Rounded value</returns>
        public static string Round(string number, int midPointRounding)
        {
            string roundedNumber;
            int pointIndex = number.IndexOf('.');
            char[] safeNumberArr = new char[number.Length + midPointRounding];
            for (int i = 0; i < number.Length; ++i)
                safeNumberArr[i] = number[i];

            if (safeNumberArr[pointIndex + midPointRounding + 1] >= '5')
            {
                safeNumberArr[pointIndex + midPointRounding] += (char)('1' - '0');
            }
            roundedNumber = new string(safeNumberArr).Substring(0, pointIndex + midPointRounding + 1);
            return roundedNumber;
        }
    }
}
