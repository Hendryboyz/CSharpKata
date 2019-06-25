// https://leetcode.com/problems/compare-version-numbers/

namespace Kata.LeetCode
{
    public class VersionComparison
    {
        public int Compoare(string version1, string version2)
        {
            int v1Length = version1.Length;
            int v2Length = version2.Length;

            int r1Start = 0;
            int r2Start = 0;

            while (r1Start < v1Length || r2Start < v2Length)
            {
                int r1End = r1Start;
                int r2End = r2Start;
                while (r1End < v1Length && version1[r1End] != '.') r1End++;
                while (r2End < v2Length && version2[r2End] != '.') r2End++;

                int r1 = r1Start < v1Length ? int.Parse(version1.Substring(r1Start, r1End - r1Start)) : 0;
                int r2 = r2Start < v2Length ? int.Parse(version2.Substring(r2Start, r2End - r2Start)) : 0;

                if (r1 > r2)
                {
                    return 1;
                }
                else if (r1 < r2)
                {
                    return -1;
                }
                r1Start = r1End + 1;
                r2Start = r2End + 1;
            }
            return 0;
        }
    }
}
