public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1)
            return s;

        int row = 0;
        int index = 0;
        char[] chars = s.ToCharArray();
        string res = "";
        bool goingDown = true;

        for (int i = 0; i < s.Length; i++)
        {
            res += chars[index];

            int jump;
            if (row == 0 || row == (numRows - 1))
                jump = 2 * (numRows - 1);
            else
                if (goingDown)
                    jump = 2 * (numRows - row - 1);
                else
                    jump = 2 * row;

            index += jump;
            goingDown = !goingDown;

            if (index > s.Length - 1)
            {
                row += 1;
                index = row;
                goingDown = true;
            }
        }

        return res;
    }
}
