public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0) return 0;

        string longest = "";
        char[] chars = s.ToCharArray();

        for (int i = 0; i < s.Length; i++)
        {
            string current = GetLongest(chars, i);
            if (longest.Length < current.Length)
                longest = current;
        }

        return longest.Length;
    }

    private string GetLongest(char[] chars, int startIndex)
    {
        string s = "";

        for (int i = startIndex; i < chars.Length; i++)
        {
            if (s.Contains(chars[i]))
                break;
            else
                s += chars[i];
        }

        return s;
    }
}
