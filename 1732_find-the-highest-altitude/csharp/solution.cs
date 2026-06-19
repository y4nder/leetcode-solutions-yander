public class Solution
{
    public int LargestAltitude(int[] gain)
    {
        int max = 0;
        int altitude = 0;

        foreach (int g in gain)
        {
            altitude += g;
            if (max < altitude)
                max = altitude;
        }

        return max;
    }
}
