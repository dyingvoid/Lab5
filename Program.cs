// Copyright 2022 dyingvoid

using Lab5;

class Program
{
    public static void Main()
    {
        string option = Console.ReadLine();
        while (option != "q")
        {
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
            
            if (CheckInputTask1(input))
            {
                continue;
            }

            if(int.TryParse(input, out intToChar))
            {
                Console.WriteLine((char)intToChar);
            }
            else if(float.TryParse(input, out floatCompare2))
            {
                if (CheckForIntOverFlowTask1(input))
                    continue;
                
                if (floatCompare2 == floatCompare1)
                    break;
                floatCompare1 = floatCompare2;
            }
        }
    }

    public static bool CheckInputTask1(string input)
    {
        bool answer = true;
        List<char> checkList = new List<char>()
        {
            '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', '-', '.'
        };
        if (string.IsNullOrEmpty(input) || input.Length == 0 || !StringManager.CheckForWrongChars(input, checkList))
        {
            Console.WriteLine("Your input contains wrong characters," +
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

    public static void ExecuteSecondTask()
    {
        string input = "";
        bool inputIsInt = true;
        while(inputIsInt)
        {
            input = Console.ReadLine();
            if (CheckInput(input))
                Console.WriteLine(StringManager.FindSumOfDigitsInNumber(input));
            else
                Console.WriteLine("Invalid input - input must be integer number.");
        }
    }

    public static bool CheckInput(string input)
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
}
