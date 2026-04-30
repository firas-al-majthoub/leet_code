public class Solution
{
    public bool IsPalindrome(int x)
    {
        return x >= 0 && IsPalindrome(x.ToString().ToCharArray());
    }

    private bool IsPalindrome(char[] chars)
    {
        int left = 0;
        int right = chars.Length - 1;

        while (left < right)
        {
            if (chars[left] != chars[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}
