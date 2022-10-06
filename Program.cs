// Copyright 2022 dyingvoid

using Lab5;

class Program
{
    public static void Main()
    {
        string option = "";
        while (option != "q")
        {
            option = Console.ReadLine();
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
        int intToChar = 0;
        float floatCompare1 = float.NaN;
        float floatCompare2 = float.NaN;
        while (input != "q")
        {
            input = Console.ReadLine();
            
            if (!CheckInputToBeIntOrFloat(input))
            {
                continue;
            }

            if(int.TryParse(input, out intToChar))
            {
                Console.WriteLine((char)intToChar);
            }
            else if(float.TryParse(input, out floatCompare2))
            {
                if (!CheckForIntOverFlowTask1(input))
                    continue;
                
                if (CompareFloats(floatCompare1, floatCompare2, 0.1))
                    break;
                floatCompare1 = floatCompare2;
            }
        }
    }

    public static bool CheckInputToBeIntOrFloat(string input)
    {
        bool answer = true;
        List<char> checkList = new List<char>()
        {
            '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '-', '.'
        };
        if (string.IsNullOrEmpty(input) || input.Length == 0 || !StringManager.CheckForWrongChars(input, checkList))
        {
            Console.WriteLine("Your input contains wrong characters. " +
                              "Input must be integer or float val");
            answer = false;
        }

        return answer;
    }

    public static bool CheckForIntOverFlowTask1(string input)
    {
        bool answer = true;
        if (!input.Contains('.') && StringManager.IsLess(input, int.MaxValue.ToString()))
        {
            Console.WriteLine($"You entered too big number, integer value must fit in {int.MinValue} : " +
                              $"{int.MaxValue} range.");
            answer = false;
        }

        return answer;
    }

    public static bool CompareFloats(float first, float second, double eps)
    {
        bool answer = false;
        float absFirst = Math.Abs(first);
        float absSecond = Math.Abs(second);
        float absDif = Math.Abs(absFirst - absSecond);
        if (absDif <= 0 + eps && absDif >= 0 - eps)
            answer = true;
        return answer;
    }

    public static void ExecuteSecondTask()
    {
        string input = "";
        bool inputIsInt = true;
        while(inputIsInt)
        {
            input = Console.ReadLine();
            if (CheckInputTask2(input))
                Console.WriteLine(StringManager.FindSumOfDigitsInNumber(input));
            else
                Console.WriteLine("Invalid input - input must be integer number.");
        }
    }

    public static bool CheckInputTask2(string input)
    {
        bool answer = input.Length > 0 &&
            StringManager.CheckForWrongChars(input);
        if (answer)
        {
            if (StringManager.IsNegative(input))
                answer = !StringManager.IsLess(input, int.MinValue.ToString());
            else
                answer = !StringManager.IsLess(input, int.MaxValue.ToString());
        }
        return answer;
    }

    public static void ExecuteFourthTask()
    {
        Console.WriteLine("Enter size of array as integer number.");
        while (true)
        {
            string inputArrStr = Console.ReadLine();
            Console.WriteLine("Input passed.");
            var inputArr = new List<int>();
            if (CheckInputTask4(inputArrStr, ref inputArr))
            {
                inputArr.ForEach(Console.WriteLine);
            }
        }
    }

    public static bool CheckInputTask4(string input, ref List<int> inputArr)
    {
        bool answer;
        if (!string.IsNullOrEmpty(input))
        {
            List<string> inputArrStr = new List<string>(input.Split(" "));
            answer = inputArrStr.Any(num => CheckInputToBeIntOrFloat(num) && 
                                         CheckForIntOverFlowTask1(num));
            if (answer)
                inputArr = inputArrStr.Select(int.Parse).ToList();
            else 
                Console.WriteLine("At least one value is not a number.");
        }
        else
        {
            answer = false;
            Console.WriteLine("Null or empty input.");
        }

        return answer;
    }
    
    
    
    
}
