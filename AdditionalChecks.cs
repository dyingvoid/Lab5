namespace Lab5;

public static class AdditionalChecks
{
    /// <summary>
    /// Checks input to be number using
    /// StringManager.IsInt() and StringManager.IsFloat()
    /// </summary>
    /// <param name="input">number in string format</param>
    /// <returns>True for number, false for not a number, null or empty</returns>
    public static bool CheckInputToBeIntOrFloat(string input)
    {
        bool answer = true;
        if (string.IsNullOrEmpty(input) ||
            !(StringManager.IsInt(input) || StringManager.IsFloat(input)))
        {
            Console.WriteLine("Your input contains wrong characters. " +
                              "Input must be integer or float val");
            answer = false;
        }

        return answer;
    }
    
    /// <summary>
    /// Checks for Int32 overflow using StringManager.IsBigger()
    /// </summary>
    /// <param name="input">Integer number in string format</param>
    /// <returns>
    /// True for Int32 and float, false for overflow.
    /// Undefined behaviour for not a number
    /// </returns>
    public static bool CheckForIntOverFlow(string input)
    {
        bool answer = true;
        if (!input.Contains('.') && StringManager.IsBigger(input, int.MaxValue.ToString()))
        {
            Console.WriteLine($"You entered too big number, integer value must fit in {int.MinValue} : " +
                              $"{int.MaxValue} range.");
            answer = false;
        }

        return answer;
    }
    
    
    /// <summary>
    /// Checks if number is integer and fits in Int32 size.
    /// </summary>
    /// <param name="input"></param>
    /// <returns>
    /// True for Int32, false for overflow.
    /// Undefined for not a number.
    /// </returns>
    public static bool CheckInputToBeInt32(string input)
    {
        bool answer = input.Length > 0 &&
                      StringManager.IsInt(input);
        if (answer)
        {
            if (StringManager.IsNegative(input))
                answer = !StringManager.IsBigger(input, int.MinValue.ToString());
            else
                answer = !StringManager.IsBigger(input, int.MaxValue.ToString());
        }
        return answer;
    }

    public static bool CheckArrayElemsToBeNums(string input, ref List<string> inputArr)
    {
        bool answer;    
        if (!string.IsNullOrEmpty(input))
        {
            List<string> inputArrStr = new List<string>(input.Split(" "));
            answer = inputArrStr.TrueForAll(num => CheckInputToBeIntOrFloat(num) &&
                                                   CheckForIntOverFlow(num));
            if (answer)
                inputArr = inputArrStr;
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
