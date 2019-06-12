namespace Kata.CodeWar
{
    public class IpConverter
    {
        public string Convert(uint intIp)
        {
            string[] ipPart = new string[4];
            for (int partIndex = 3; partIndex >= 0; partIndex--)
            {
                ipPart[partIndex] = System.Convert.ToString(intIp % 256U);
                intIp /= 256U;
            }
            return string.Join(".", ipPart);
        }
    }
}
