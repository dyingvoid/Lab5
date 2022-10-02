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
        while(input != "q")
        {
            input = Console.ReadLine();

            int integerToCharVal = 0;
            bool intOverflow = CheckForIntOverflow(input);
            Console.WriteLine(intOverflow);
            float floatToCompare = float.NaN;
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
