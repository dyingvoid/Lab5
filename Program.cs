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
                Console.WriteLine("You have entered menu");
                option = Console.ReadLine() ?? string.Empty;
                switch (option)
                {
                    case "1":
                        Console.WriteLine("FirstTask");
                        ExecuteTaskFirst();
                        break;
                    case "2":
                        Console.WriteLine("SecondTask");
                        ExecuteSecondTask();
                        break;
                    case "4":
                        Console.WriteLine("Executing task 4");
                        ExecuteFourthTask();
                        break;
                    case "q":
                        break;
                    default:
                        Console.WriteLine("Wrong Input.");
                        break;
                }
            }
        }

        public static void ExecuteTaskFirst()
        {
            string input = "";
            int intToChar;
            float floatCompare1 = float.NaN;
            float floatCompare2 = float.NaN;
            while (input != "q")
            {
                input = Console.ReadLine() ?? string.Empty;

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
                    if (!AdditionalChecks.CheckForIntOverFlow(input))
                        continue;

                    if (CompareFloats(floatCompare1, floatCompare2, 0.1))
                        break;
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

        public static void ExecuteSecondTask()
        {
            string input;
            bool inputIsInt = true;
            while (inputIsInt)
            {
                input = Console.ReadLine() ?? string.Empty;
                if (AdditionalChecks.CheckInputToBeInt32(input))
                    Console.WriteLine(StringManager.FindSumOfDigitsInNumber(input));
                else
                    Console.WriteLine("Invalid input - input must be integer number.");
            }
        }

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
                    outputArr.ForEach(Console.WriteLine);
                }
            }
        }

        public static List<string> OperateInputArray(List<string> inputArr)
        {
            var outputArr = new List<string>();
            foreach (var num in inputArr)
            {
                if (StringManager.IsInt(num) && !StringManager.IsNegative(num))
                {
                    int res = Enumerable.Range(1, int.Parse(num)).Aggregate(1, (p, item) => p * item);
                    outputArr.Add(res.ToString());
                }
                else if (StringManager.IsFloat(num))
                {
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