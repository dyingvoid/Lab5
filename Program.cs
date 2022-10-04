// Copyright 2022 dyingvoid

using Lab5;

class Program
{
    public static void Main()
    {
        //ExecuteTaskFirst();
        ExecuteSecondTask();
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

            if(int.TryParse(input, out intToChar))
            {
                Console.WriteLine((char)intToChar);
            }
            else if(float.TryParse(input, out floatCompare2))
            {
                if (floatCompare2 == floatCompare1)
                    break;
                floatCompare1 = floatCompare2;
            }
        }
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
                answer = !StringManager.CheckForIntOverflow(input, int.MinValue.ToString());
            else
                answer = !StringManager.CheckForIntOverflow(input, int.MaxValue.ToString());
        }
        return answer;
    }
}
