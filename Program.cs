// Copyright 2022 dyingvoid

using System.IO.Compression;

class Program
{
    public static void Main()
    {
        ExecuteTaskFirst();
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

    public static bool CheckForIntOverflow(string input)
    {
        bool answer = false;
        string maxInt = int.MaxValue.ToString();
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
