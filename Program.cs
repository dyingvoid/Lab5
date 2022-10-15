// Copyright 2022 dyingvoid

namespace Lab5
{
    static class Program
    {
        public static void Main()
        {
            string option = "";
            while (option != "q")
            {
                Console.WriteLine("You have entered menu, enter: 1 for 1st task, 2 for 2nd task, " +
                                  "4 for 4th task, and q for quit.");
                option = Console.ReadLine() ?? string.Empty;
                switch (option)
                {
                    case "1":
                        Console.WriteLine("First task.");
                        ExecuteTaskFirst();
                        break;
                    case "2":
                        Console.WriteLine("Second task.");
                        ExecuteSecondTask();
                        break;
                    case "4":
                        Console.WriteLine("Fourth task.");
                        ExecuteFourthTask();
                        break;
                    case "q":
                        Console.WriteLine("Shutting down.");
                        break;
                    default:
                        Console.WriteLine("Wrong Input.");
                        break;
                }
            }
        }

        /// <summary>
        /// for int input returns corresponding char,
        /// for two floats in a row that are equal, breaks
        /// for 'q' also breaks
        /// </summary>
        public static void ExecuteTaskFirst()
        {
            string input = "";
            float floatCompare1 = float.NaN;
            float floatCompare2 = float.NaN;
            while (input != "q")
            {
                input = Console.ReadLine() ?? string.Empty;
                int intToChar;  

                if (!AdditionalChecks.CheckInputToBeIntOrFloat(input))
                {
                    continue;
                }

                if (int.TryParse(input, out intToChar))
                {
                    Console.WriteLine((char)intToChar);
                }
                else if (float.TryParse(input, out floatCompare2))
                {
                    //for some reason huge int numbers can be parsed to float
                    //Does not activate for floats
                    if (AdditionalChecks.CheckForIntOverFlow(input))
                        continue;

                    if (CompareFloats(floatCompare1, floatCompare2, 0.1))
                        break;
                    //if not, remembering float in flComp1, to store new one in flComp2
                    floatCompare1 = floatCompare2;
                }
            }
        }

        public static bool CompareFloats(float first, float second, double eps)
        {
            bool answer = false;
            float absDif = Math.Abs(first - second);
            if (absDif <= 0 + eps && absDif >= 0 - eps)
                answer = true;
            return answer;
        }

        /// <summary>
        /// Checks input to be int and prints sum of it's digits
        /// otherwise breaks
        /// </summary>
        public static void ExecuteSecondTask()
        {
            string input;
            bool inputIsInt = true;
            while (inputIsInt)
            {
                input = Console.ReadLine() ?? string.Empty;
                if (AdditionalChecks.CheckInputToBeInt32(input))
                {
                    Console.WriteLine(StringManager.FindSumOfDigitsInNumber(input));
                }
                else
                {
                    Console.WriteLine("Invalid input - input must be integer number.");
                    inputIsInt = false;
                }

            }
        }

        /// <summary>
        /// Operates entered array(see OperateInputArray),
        /// if successfully, displays entered and output arrays and breaks,
        /// repeats input if not
        /// </summary>
        public static void ExecuteFourthTask()
        {
            Console.WriteLine("Enter array with spaces between numbers.");
            while (true)
            {
                string inputArrStr = Console.ReadLine() ?? string.Empty;
                var inputArr = new List<string>();
                if (AdditionalChecks.CheckArrayElemsToBeNums(inputArrStr, ref inputArr))
                {
                    var outputArr = OperateInputArray(inputArr);
                    Console.WriteLine(string.Join(", ", inputArr));
                    Console.WriteLine(string.Join(", ", outputArr));
                    break;
                }
            }
        }
        
        /// <summary>
        /// For entered array changes it's positive ints with theirs factorial,
        /// for positive and negative floats, takes away int part,
        /// and does not affect negative ints
        /// </summary>
        /// <param name="inputArr"></param>
        /// <returns></returns>
        public static List<string> OperateInputArray(List<string> inputArr)
        {
            var outputArr = new List<string>();
            foreach (var num in inputArr)
            {
                if (StringManager.IsInt(num) && !StringManager.IsNegative(num))
                {
                    //short form to find factorial
                    int res = Enumerable.Range(1, int.Parse(num)).Aggregate(1, (p, item) => p * item);
                    outputArr.Add(res.ToString());
                }
                else if (StringManager.IsFloat(num))
                {
                    //rounding num and cutting integer part
                    string res = StringManager.RoundAndCut(num, 2);
                    outputArr.Add(res);
                }
                else
                {
                    outputArr.Add(num);
                }
            }
            return outputArr;
        }
    }
}