// Copyright 2022 dyingvoid

using System.IO.Compression;

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
            Console.WriteLine(FindSumOfDigitsInNumber(input));
        }
    }

    public static int FindSumOfDigitsInNumber(string input)
    {
        char minNumber = '0';
        foreach(var ch in input)
        {
            minNumber += ch;
        }
        return minNumber - '0' - (48 * input.Length);
    }

    //Check if set formed from input is subset of checking set
    //returns true for empty string, check docs to know why
    public static bool CheckForWrongChars(string input)
    {
        //using two hashsets is claimed to be O(n)
        var inputSet = new HashSet<char>(input);
        var testingSet = new HashSet<char>(
            new char[] { '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }
            );
        return inputSet.IsProperSubsetOf(testingSet);
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

    public static bool CheckForIntOverflow(string input, int value)
    {
        bool answer = false;
        string maxInt = value.ToString();
        if(input.Length > maxInt.Length)
        {
            answer = true;
        }
        else if(input.Length == maxInt.Length)
        {
            foreach(var (inputChar, maxIntChar) in input.Zip(maxInt))
            {
                if (inputChar > maxIntChar)
                    answer = true;
            }
        }
        return answer;
    }
}
