namespace Kata.Game
{
    public class BouncingBall
    {
        public int ExpectBouncingTimes(double ballHeight, double bounceFactor, double windowHeight)
        {
            if (!IsValidParameters(ballHeight, bounceFactor, windowHeight))
            {
                return -1;
            }
            int times = 1;
            while (ballHeight >= windowHeight)
            {
                ballHeight *= bounceFactor;
                if (ballHeight > windowHeight)
                {
                    times += 2;
                }
                else if (ballHeight == windowHeight)
                {
                    times += 1;
                }
            }
            return times;
        }

        private bool IsValidParameters(double ballHeight, double bounceFactor, double windowHeight)
        {
            return ballHeight > 0 && 
                (0 < bounceFactor && bounceFactor < 1) &&
                windowHeight < ballHeight;
        }
    }
}
