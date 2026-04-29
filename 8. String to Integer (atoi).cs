public class Solution
{
    public int MyAtoi(string s)
    {
        s = s.Trim();

        long res = 0;
        bool isNegative = false;
        bool readSign = false;
        bool numberReadingStarted = false;
        char[] chars = s.ToCharArray();

        for (int i = 0; i < s.Length; i++)
        {
            char currentChar = chars[i];

            if ((!isDigit(currentChar) && !isSign(currentChar)) || (readSign && isSign(currentChar)))
                break;

            if (numberReadingStarted)
            {
                if (isSign(currentChar))
                    break;

                res = (res * 10) + long.Parse(currentChar.ToString());

                if (!isNegative && res >= int.MaxValue)
                    return int.MaxValue;

                if (isNegative && (res * -1) <= int.MinValue)
                    return int.MinValue;
            }
            else
            {
                if (isSign(currentChar))
                {
                    readSign = true;
                    if (currentChar == '-')
                        isNegative = true;
                }
                else if (isDigit(currentChar))
                {
                    numberReadingStarted = true;

                    res = (res * 10) + long.Parse(currentChar.ToString());

                    if (!isNegative && res >= int.MaxValue)
                        return int.MaxValue;

                    if (isNegative && (res * -1) <= int.MinValue)
                        return int.MinValue;
                }
            }
        }

        return ((int)res) * (isNegative ? -1 : 1);
    }

    private bool isDigit(char c)
    {
        return char.IsDigit(c);
    }

    private bool isSign(char c)
    {
        return c == '-' || c == '+';
    }
}
