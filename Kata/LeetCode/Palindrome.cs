// https://leetcode.com/problems/valid-palindrome/

namespace Kata.LeetCode
{
    public class Palindrome
    {
        public bool IsPalindrome(string s)
        {
            int lastIdx = s.Length - 1;
            int end = lastIdx;
            int start = 0;
            while (start < end)
            {
                while (start < lastIdx && !char.IsLetterOrDigit(s[start]))
                {
                    start++;
                }
                while (0 <= end && !char.IsLetterOrDigit(s[end]))
                {
                    end--;
                }
                if (start < lastIdx && 0 <= end &&
                    !char.ToLower(s[start]).Equals(char.ToLower(s[end])))
                {
                    return false;
                }
                start++;
                end--;
            }
            return true;
        }
    }
}
