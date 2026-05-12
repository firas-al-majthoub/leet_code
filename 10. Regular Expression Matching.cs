// using System.Text.RegularExpressions;

public class Solution
{
    /* ================ CODE BELOW USES BOTTOM-UP DP ================ */

    public bool IsMatch(string s, string p)
    {
        return IsMatch(s.ToCharArray(), p.ToCharArray());
    }

    private bool IsMatch(char[] text, char[] pattern)
    {
        bool[,] dp = new bool[text.Length + 1, pattern.Length + 1];
        dp[text.Length, pattern.Length] = true;

        for (int i = text.Length; i >= 0; i--)
        {
            for  (int j = pattern.Length - 1; j >= 0; j--)
            {
                bool firstMatch = i < text.Length && (pattern[j] == '.' || pattern[j] == text[i]);

                if (j + 1 < pattern.Length && pattern[j + 1] == '*')
                {
                    dp[i, j] = dp[i, j + 2] || (firstMatch && dp[i + 1, j]);
                }
                else
                {
                    dp[i, j] = firstMatch && dp[i + 1, j + 1];
                }
            }
        }

        return dp[0, 0];
    }



    /* ================ CODE BELOW USES RECURSION WITH TOP-DOWN DP ================ */

    // public bool IsMatch(string s, string p)
    // {
    //     bool?[,] dp = new bool?[s.Length + 1, p.Length + 1];
    //     return IsMatch(s.ToCharArray(), p.ToCharArray(), 0, 0, dp);
    // }

    // private bool IsMatch(char[] text, char[] pattern, int i, int j, bool?[,] dp)
    // {
    //     if (dp[i, j] != null) return dp[i, j].Value;

    //     bool res;

    //     if (j == pattern.Length)
    //     {
    //         res = i == text.Length;
    //     }
    //     else
    //     {
    //         bool firstMatch = i < text.Length && (pattern[j] == '.' || pattern[j] == text[i]);

    //         if (j + 1 < pattern.Length && pattern[j + 1] == '*')
    //         {
    //             return IsMatch(text, pattern, i, j + 2, dp) || (firstMatch && IsMatch(text, pattern, i + 1, j, dp));
    //         }
    //         else
    //         {
    //             return firstMatch && IsMatch(text, pattern, i + 1, j + 1, dp);
    //         }
    //     }

    //     dp[i, j] = res;
    //     return res;
    // }


    /* ================ CODE BELOW USES RECURSION ================ */

    // public bool IsMatch(string s, string p)
    // {
    //     char[] text = s.ToCharArray();
    //     char[] pattern = p.ToCharArray();

    //     if (p == "") return s == "";

    //     bool firstMatch = s != "" && (pattern[0] == '.' || pattern[0] == text[0]);

    //     if (pattern.Length > 1 && pattern[1] == '*')
    //     {
    //         return IsMatch(s, p.Substring(2)) || (firstMatch && IsMatch(s.Substring(1), p));
    //     }
    //     else
    //     {
    //         return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
    //     }
    // }


    /* ================ CODE BELOW SUBSTITUTES THE SYMBOLS FROM THE PROBLEM WITH SYMBOLS OF REG EXP AND CHECKS IT USING BUILT IN FUNCTIONALITY ================ */

    // private bool IsMatch(char[] pattern, string s)
    // {
    //     string regex = "^";

    //     for (int i = 0; i < pattern.Length; i++)
    //     {
    //         char current = pattern[i];
    //         char? next = i + 1 < pattern.Length ? pattern[i + 1] : null;


    //         if (next == '*')
    //         {
    //             if (current == '.')
    //                 regex += "[a-z]*";
    //             else
    //                 regex += $"[{current}]*";

    //             i++;
    //         }
    //         else
    //         {
    //             if (current == '.')
    //                 regex += ".";
    //             else
    //                 regex += current;
    //         }
    //     }

    //     regex += "$";
    //     return Regex.IsMatch(s, regex);
    // }



    /* ================ CODE BELOW DOES NOT WORK ================ */




    // private bool IsMatch(char[] pattern, char[] phrase)
    // {
    //     int index = 0;

    //     for (int i = 0; i < pattern.Length; i++)
    //     {
    //         char p = pattern[i];
    //         char? pNext = i + 1 < pattern.Length ? pattern[i + 1] : null;
    //         char? pNextNext = i + 2 < pattern.Length ? pattern[i + 2] : null;

    //         if (pNext == '*')
    //         {
    //             if (p == '.')
    //             {
    //                 if (pNextNext == null)
    //                     return true;

    //                 index = ZeroOrMoreCharsUntil(pNextNext.Value, phrase, index);
    //             }
    //             else
    //             {
    //                 bool leaveOne = pNextNext == p;
    //                 index = ZeroOrMoreChars(p, phrase, index, leaveOne);
    //             }

    //             i++;
    //         }
    //         else if (index >= phrase.Length)
    //         {
    //             return false;
    //         }
    //         else if (p == '.')
    //         {
    //             index++;
    //         }
    //         else
    //         {
    //             if (p != phrase[index])
    //                 return false;

    //             index++;
    //         }
    //     }

    //     return index >= phrase.Length;
    // }

    // private int ZeroOrMoreCharsUntil(char c, char[] phrase, int index)
    // {
    //     while (index < phrase.Length)
    //     {
    //         if (phrase[index] == c)
    //             break;

    //         index++;
    //     }

    //     return index;
    // }

    // private int ZeroOrMoreChars(char c, char[] phrase, int index, bool leaveOne)
    // {
    //     while (index < phrase.Length)
    //     {
    //         char? next = index + 1 < phrase.Length ? phrase[index] : null;

    //         if (phrase[index] != c)
    //             break;

    //         if (leaveOne && (next == null || next != c))
    //             break;

    //         index++;
    //     }

    //     return index;
    // }
}
