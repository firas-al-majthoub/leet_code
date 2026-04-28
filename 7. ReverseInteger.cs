public class Solution
{
    char[] maxInt = int.MaxValue.ToString().ToCharArray();
    char[] minInt = int.MinValue.ToString().Substring(1).ToCharArray();

    public int Reverse(int x)
    {
        bool isNegative = x < 0;
        string num = x.ToString();

        if (isNegative)
        {
            if (num.Length < 11)
                return int.Parse("-" + ReverseStr(num.Substring(1)));
            else
            {
                string res = ReverseStr(num.Substring(1));
                return IsInRangeN(res) ? int.Parse("-" + res) : 0;
            }
        }
        else
        {
            if (num.Length < 10)
                return int.Parse(ReverseStr(num));
            else
            {
                string res = ReverseStr(num);
                return IsInRangeP(res) ? int.Parse(res) : 0;
            }
        }
    }

    private string ReverseStr(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private bool IsInRangeP(string num)
    {
        char[] numChars = num.ToCharArray();

        for (int i = 0; i < numChars.Length; i++)
            if (int.Parse(numChars[i].ToString()) < int.Parse(maxInt[i].ToString()))
                return true;
            else if (int.Parse(numChars[i].ToString()) > int.Parse(maxInt[i].ToString()))
                return false;

        return true;
    }

    private bool IsInRangeN(string num)
    {
        char[] numChars = num.ToCharArray();

        for (int i = 0; i < numChars.Length; i++)
            if (int.Parse(numChars[i].ToString()) < int.Parse(minInt[i].ToString()))
                return true;
            else if (int.Parse(numChars[i].ToString()) > int.Parse(minInt[i].ToString()))
                return false;

        return true;
    }
}
