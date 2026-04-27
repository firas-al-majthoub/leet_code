public class Solution
{
    public string LongestPalindrome(string s)
    {
        if (s.Length == 1)
            return s;

        char[] chars = s.ToCharArray();
        string longest = "";

        for (int i = 0; i < s.Length - 1; i++)
        {
            char currentChar = chars[i];
            int charCount = s.Count(currentChar);
            int splitIndex = i + 1;

            for (int j = 0; j < charCount; j++)
            {
                int nextSameChar = s.Substring(splitIndex).IndexOf(currentChar) + splitIndex;
                splitIndex = nextSameChar + 1;

                string check = s.Substring(i, nextSameChar - i + 1);
                if ((longest.Length < check.Length) && IsPalindrome(check))
                    longest = check;
            }
        }

        return longest;
    }

    private bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;
        char[] chars = s.ToCharArray();

        while (left < right)
        {
            if (chars[left] != chars[right])
                return false;

            left += 1;
            right -= 1;
        }

        return true;
    }
}
